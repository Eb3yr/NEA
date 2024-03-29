﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NEA.Classes.Algorithms;
using System.Threading;

namespace NEA.Classes
{
    public partial class GUIWindow : Form //Might make it generic and parse in String in Program.cs in the future. Right now it's hard-coded to use strings for node names
    {
        protected AdjacencyList<string> currentAdjList, savedAdjList, tempAdjList, MSTAdjList;
        protected GraphWindow<string> graphWindow;
        protected Kruskals<string> KruskalsAlgorithm;
        protected Prims<string> PrimsAlgorithm;
        protected Dijkstras<string> DijkstrasAlgorithm;
        protected double MST;

        public GUIWindow()
        {
            InitializeComponent();
            currentAdjList = new AdjacencyList<string>();
            MSTAdjList = new AdjacencyList<string>();
            graphWindow = new GraphWindow<string>();
            MST = -1;
        }

        #region Handling Check Boxes

        private void CheckBoxEditNodes_MouseClick(object sender, MouseEventArgs e)
        {
            CheckBoxEditEdges.Checked = !CheckBoxEditEdges.Checked;
            GetButtonText();
            SetVisibleInputBoxes();
        }
        private void CheckBoxEditEdges_MouseClick(object sender, MouseEventArgs e)
        {
            CheckBoxEditNodes.Checked = !CheckBoxEditNodes.Checked;
            GetButtonText();
            SetVisibleInputBoxes();
        }


        private void CheckBoxAdd_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckBoxAdd.Checked == true)
            {
                if (CheckBoxUpdate.Checked == CheckBoxAdd.Checked)
                {
                    CheckBoxUpdate.Checked = !CheckBoxUpdate.Checked;
                }
                if (CheckBoxDelete.Checked == CheckBoxAdd.Checked)
                {
                    CheckBoxDelete.Checked = !CheckBoxDelete.Checked;
                }
            }
            else
            {
                CheckBoxAdd.Checked = true;
            }
            GetButtonText();
            SetVisibleInputBoxes();
        }
        private void CheckBoxUpdate_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckBoxUpdate.Checked == true)
            {
                if (CheckBoxAdd.Checked = CheckBoxUpdate.Checked)
                {
                    CheckBoxAdd.Checked = !CheckBoxAdd.Checked;
                }
                if (CheckBoxDelete.Checked == CheckBoxUpdate.Checked)
                {
                    CheckBoxDelete.Checked = !CheckBoxDelete.Checked;
                }
            }
            else
            {
                CheckBoxUpdate.Checked = true;
            }
            GetButtonText();
            SetVisibleInputBoxes();
        }
        private void CheckBoxDelete_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckBoxDelete.Checked == true)
            {

                if (CheckBoxAdd.Checked = CheckBoxDelete.Checked)
                {
                    CheckBoxAdd.Checked = !CheckBoxAdd.Checked;
                }
                if (CheckBoxUpdate.Checked == CheckBoxDelete.Checked)
                {
                    CheckBoxUpdate.Checked = !CheckBoxUpdate.Checked;
                }
            }
            else
            {
                CheckBoxDelete.Checked = true;
            }
            GetButtonText();
            SetVisibleInputBoxes();
        }
        private void GetButtonText() //Ensures the button for updating the graph has the right text
        {
            string newText = "";
            switch (CheckBoxDelete.Checked)
            {
                case true:
                    newText += "Delete";
                    break;

                case false:
                    switch (CheckBoxAdd.Checked)
                    {
                        case true:
                            newText += "Add";
                            break;
                        case false:
                            newText += "Update";
                            break;
                    }
                    break;
            }

            switch (CheckBoxEditNodes.Checked)
            {
                case true:
                    newText += " Node";
                    break;

                case false:
                    newText += " Edge";
                    break;
            }

            UpdateAdjListButton.Text = newText;
        }

        private void SetVisibleInputBoxes()
        {
            //Set the visibility of various inputs here, call after anything changing the check boxes "Add, Update, Delete, Edit Nodes, Edit Edges"

            switch (UpdateAdjListButton.Text)
            {
                case "Add Node":
                    SrcNodeLabel.Visible = true;
                    SrcNodeTextBox.Visible = true;
                    DestNodeLabel.Text = "Destination Node Name";
                    DestNodeLabel.Visible = false;
                    DestNodeTextBox.Visible = false;
                    EdgeWeightLabel.Visible = false;
                    EdgeWeightTextBox.Visible = false;
                    break;

                case "Update Node":
                    SrcNodeLabel.Visible = true;
                    SrcNodeTextBox.Visible = true;
                    DestNodeLabel.Text = "New Node Name";
                    DestNodeLabel.Visible = true;
                    DestNodeTextBox.Visible = true;
                    EdgeWeightLabel.Visible = false;
                    EdgeWeightTextBox.Visible = false;
                    break;

                case "Delete Node":
                    SrcNodeLabel.Visible = true;
                    SrcNodeTextBox.Visible = true;
                    DestNodeLabel.Text = "Destination Node Name";
                    DestNodeLabel.Visible = false;
                    DestNodeTextBox.Visible = false;
                    EdgeWeightLabel.Visible = false;
                    EdgeWeightTextBox.Visible = false;
                    break;

                case "Add Edge":
                    SrcNodeLabel.Visible = true;
                    SrcNodeTextBox.Visible = true;
                    DestNodeLabel.Text = "Destination Node Name";
                    DestNodeLabel.Visible = true;
                    DestNodeTextBox.Visible = true;
                    EdgeWeightLabel.Visible = true;
                    EdgeWeightTextBox.Visible = true;
                    break;

                case "Update Edge":
                    SrcNodeLabel.Visible = true;
                    SrcNodeTextBox.Visible = true;
                    DestNodeLabel.Text = "Destination Node Name";
                    DestNodeLabel.Visible = true;
                    DestNodeTextBox.Visible = true;
                    EdgeWeightLabel.Visible = true;
                    EdgeWeightTextBox.Visible = true;
                    break;

                case "Delete Edge":
                    SrcNodeLabel.Visible = true;
                    SrcNodeTextBox.Visible = true;
                    DestNodeLabel.Text = "Destination Node Name";
                    DestNodeLabel.Visible = true;
                    DestNodeTextBox.Visible = true;
                    EdgeWeightLabel.Visible = false;
                    EdgeWeightTextBox.Visible = false;
                    break;
            }
        }

        #endregion

        #region Saving and Loading

        private void SaveGraph_Click(object sender, EventArgs e)
        {
            if (IsSaveToVar.Checked == true)
            {
                savedAdjList = currentAdjList.DeepCopy();
                UpdateListView();
                graphWindow.UpdateAdjList(currentAdjList);
            }
            else
            {
                //Save to local storage instead
                WriteFileToLocal();
            }

        }

        private void SaveAsGraphLocally_Click(object sender, EventArgs e)
        {
            if (IsSaveToLocal.Checked == true)
            {
                SaveFileDialogue.ShowDialog();
                try
                {
                    //Does WriteFileToLocal(); in the SaveFileDialogue_FileOk() method so that it only occurs on a successful selection
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Error writing to file!");
                }
            }
        }

        private void LoadGraph_Click(object sender, EventArgs e)
        {
            switch (IsSaveToVar.Checked)
            {
                case true:
                    if (savedAdjList != null) //if instantiated
                    {
                        Console.WriteLine("Loading");
                        currentAdjList = savedAdjList.DeepCopy();
                        UpdateListView();
                        graphWindow.UpdateAdjList(currentAdjList);
                    }
                    else
                    {
                        Console.WriteLine("Error loading from file!");
                    }
                    //Doesn't do anything if there's nothing in the saved adjacency list to prevent accidental data loss
                    break;

                case false:
                    LoadFileDialogue.ShowDialog();
                    break;
            }
        }
        private void LoadFromFile()
        {
            currentAdjList = new AdjacencyList<string>();
            string[] tempListOuter, tempListInner, individualEdge;
            string[] fileData = File.ReadAllLines(LoadFileDialogue.FileName);

            if (fileData.Length > 0)
            {
                foreach (string i in fileData)
                {
                    tempListOuter = i.Split('|');
                    tempListInner = tempListOuter[1].Split(';');
                    currentAdjList.AddNode(tempListOuter[0]);

                    foreach (string f in tempListInner)
                    {
                        individualEdge = f.Split(',');
                        try
                        {
                            currentAdjList.AddEdge(tempListOuter[0], individualEdge[0], double.Parse(individualEdge[1]), true);
                        }
                        catch (Exception ex)
                        {
                            //Error loading adjacent nodes for a source node from the file
                            //Should only be happening if there are no adjacent nodes
                        }
                    }
                }

                UpdateListView(); //Because the graph may have just changed
            }
            else
            {
                Console.WriteLine("Filedata is empty!");
            }
            
        }
        private void WriteFileToLocal()
        {
            Console.WriteLine("\nwriting:");

            File.WriteAllLines(SaveFileDialogue.FileName, CreateListOfLines().ToArray()); //Will overwrite pre-existing files of this name. Need to test if it overwrites or just appends
        }
        private List<string> CreateListOfLines() //Used for writing to files and for repopulating the list view of the adjacency list
        {
            List<string> listOfLines = new List<string>();
            string tempStr = "";
            foreach (var i in currentAdjList.adjList)
            {
                tempStr += i.Key + "|";
                foreach (var f in i.Value)
                {
                    if (!f.Equals(i.Value.Last()))
                    {
                        tempStr += f.Key + "," + f.Value + ";";
                    }
                    else
                    {
                        tempStr += f.Key + "," + f.Value;
                    }
                }

                listOfLines.Add(tempStr);
                Console.WriteLine(tempStr);
                tempStr = "";
            }
            return listOfLines;
        }

        #region File Format Explanation
        /*

        The format for saved files is as follows:
        -Each KeyValuePair in the AdjacencyList.adjList dictionary is saved on a new line
        -The source node (Key) is written, followed by a vertical bar '|' to split it from the adjacent nodes
        -Each adjacent node is a combination of the node itself (the destination node) followed by the edge weight, separated by comma ','
        -Each adjacent node is separated by a semicolon ';'

        This allows me to use .Split() to easily separate each string in the string array produced by .ReadAllLines(), and lets me easily format the data to write as I just need to append certain symbols at certain times.

         */
        #endregion


        private void IsSaveToVar_MouseClick(object sender, MouseEventArgs e) //DO NOT use the CheckedChange event, it'll end up generating a CheckedChange event for the other check box and cause a stack overflow
        {
            //Save to var is initially set to true to prevent these getting out of sync. Make sure this is impossible to break later, but it doesn't seem to break now
            IsSaveToLocal.Checked = !IsSaveToLocal.Checked;
        }

        private void IsSaveToLocal_MouseClick(object sender, MouseEventArgs e)
        {
            IsSaveToVar.Checked = !IsSaveToLocal.Checked;
        }

        private void SaveFileDialogue_FileOk(object sender, CancelEventArgs e)
        {
            FilePathLabel.Text = "File path: " + SaveFileDialogue.FileName;
            SaveFileDialogue.OpenFile().Close();
            WriteFileToLocal();
        }

        private void LoadFileDialogue_FileOk(object sender, CancelEventArgs e)
        {
            LoadFileDialogue.OpenFile().Close();
            LoadFromFile();
            FilePathLabel.Text = "File path: " + LoadFileDialogue.FileName;
        }

        #endregion

        #region Changing Graph

        private void UpdateAdjListButton_Click(object sender, EventArgs e)
        {
            tempAdjList = currentAdjList; //Try-catch needs to be able to revert the graph to its previous state if something goes wrong mid-execution
            bool success = true;
            //If I have the time, add better error messages
            //Known errors that have been caught:
            //Invalid input
            //Referencing something that doesn't exist
            //Trying to add a node or edge that already exists

            //Bug with updating nodes: Says invalid, then on the second click it works. Subsequent clicks work even though that node no longer exists too???

            if (SrcNodeTextBox.Text.Trim().Length == 0 && DestNodeTextBox.Text.Trim().Length == 0 && EdgeWeightTextBox.Text.Trim().Length == 0) //If the entered text is empty, either no characters or only whitespace
            {
                UpdateMsgLabel.Text = "Please fill all necessary fields!";
                success = false;
            }
            else
            {
                switch (UpdateAdjListButton.Text)
                {
                    case "Add Node":
                        if (SrcNodeTextBox.Text.Trim().Length == 0)
                        {
                            UpdateMsgLabel.Text = "Please fill all necessary fields!";
                            success = false;
                        }
                        else
                        {
                            try
                            {
                                currentAdjList.AddNode(SrcNodeTextBox.Text);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                UpdateMsgLabel.Text = "Invalid input(s)";
                                RevertFailedUpdate(tempAdjList);
                                success = false;
                            }
                        }
                        break;

                    case "Update Node":
                        if (SrcNodeTextBox.Text.Trim().Length == 0 || DestNodeTextBox.Text.Trim().Length == 0)
                        {
                            UpdateMsgLabel.Text = "Please fill all necessary fields!";
                            success = false;
                        }
                        else
                        {
                            try
                            {
                                bool found = currentAdjList.EditNode(SrcNodeTextBox.Text, DestNodeTextBox.Text);
                                if (!found)
                                {
                                    UpdateMsgLabel.Text = "Please enter an existing source node";
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                UpdateMsgLabel.Text = "Invalid input(s)";
                                Console.WriteLine(ex.ToString());
                                RevertFailedUpdate(tempAdjList);
                                success = false;
                            }
                        }
                        break;

                    case "Delete Node":
                        if (SrcNodeTextBox.Text.Trim().Length == 0)
                        {
                            UpdateMsgLabel.Text = "Please fill all necessary fields!";
                            success = false;
                        }
                        else
                        {
                            try
                            {
                                currentAdjList.RemoveNode(SrcNodeTextBox.Text);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                UpdateMsgLabel.Text = "Invalid input(s)";
                                RevertFailedUpdate(tempAdjList);
                                success = false;
                            }
                        }
                        break;

                    case "Add Edge":
                        if (SrcNodeTextBox.Text.Trim().Length == 0 | DestNodeTextBox.Text.Trim().Length == 0 | EdgeWeightTextBox.Text.Trim().Length == 0)
                        {
                            UpdateMsgLabel.Text = "Please fill all necessary fields!";
                            success = false;
                        }
                        else
                        {
                            try
                            {
                                currentAdjList.AddEdge(SrcNodeTextBox.Text, DestNodeTextBox.Text, double.Parse(EdgeWeightTextBox.Text), IsEdgeDirectedCheckBox.Checked);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                UpdateMsgLabel.Text = "Invalid input(s)";
                                RevertFailedUpdate(tempAdjList);
                                success = false;
                            }
                        }
                        break;

                    case "Update Edge":
                        if (SrcNodeTextBox.Text.Trim().Length == 0 | DestNodeTextBox.Text.Trim().Length == 0 | EdgeWeightTextBox.Text.Trim().Length == 0)
                        {
                            UpdateMsgLabel.Text = "Please fill all necessary fields!";
                            success = false;
                        }
                        else
                        {
                            try
                            {
                                currentAdjList.EditEdge(SrcNodeTextBox.Text, DestNodeTextBox.Text, double.Parse(EdgeWeightTextBox.Text));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                UpdateMsgLabel.Text = "Invalid input(s)";
                                RevertFailedUpdate(tempAdjList);
                                success = false;
                            }
                        }
                        break;

                    case "Delete Edge":
                        if (SrcNodeTextBox.Text.Trim().Length == 0 | DestNodeTextBox.Text.Trim().Length == 0)
                        {
                            UpdateMsgLabel.Text = "Please fill all necessary fields!";
                            success = false;
                        }
                        else
                        {
                            try
                            {
                                currentAdjList.RemoveEdge(SrcNodeTextBox.Text, DestNodeTextBox.Text, IsEdgeDirectedCheckBox.Checked);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                                UpdateMsgLabel.Text = "Invalid input(s)";
                                RevertFailedUpdate(tempAdjList);
                                success = false;
                                //Could I add a help tooltip on which data types should be used?
                            }
                        }
                        break;
                }
            }

            if (success)
            {
                //Do this in each case and make it more specific if I have the time
                UpdateMsgLabel.Text = "Successfully updated graph";
                graphWindow.UpdateAdjList(currentAdjList);
                UpdateListView();
                UpdateStats();
            }

            UpdateListView();
        }
        private void UpdateStats()
        {
            int counter = 0;
            NoOfNodesLabel.Text = "Number of nodes: " + currentAdjList.adjList.Count();

            foreach (var i in currentAdjList.adjList)
            {
                counter += i.Value.Count();
            }
            NoOfEdgesLabel.Text = "Number of edges: " + counter;
            MSTSizeLabel.Text = "Minimum Spanning Tree: " + MST;
        }
        private void UpdateListView()
        {
            //Makes listview show the graph in all of its tabular glory
            //Code partially cloned from LoadFromFile(), but modified to suit modifying the list view rather than creating a new adjacency list

            List<string> listOfLines = CreateListOfLines();
            string[] tempListOuter, tempListInner, individualEdge;
            string[] row; //Should be 2 columns. A list as graphs under construction will not have edges yet, which throws errors if not handled properly
            string tempString;
            bool EdgesExist = false;

            ListViewOfNodes.Items.Clear();

            Console.WriteLine("Printing off the listOfLines: ");
            foreach (string i in listOfLines)
            {
                Console.WriteLine(i);
            }

            foreach (string i in listOfLines)
            {
                row = new string[2]; //2 columns in the listview showing the adjacency list
                tempString = "";
                EdgesExist = false;

                tempListOuter = i.Split('|');
                tempListInner = tempListOuter[1].Split(';');

                row[0] = tempListOuter[0];

                foreach (string f in tempListInner)
                {
                    try
                    {
                        individualEdge = f.Split(',');
                        if (f == tempListInner[tempListInner.Count() - 1])
                        {
                            tempString += "(" + individualEdge[0] + ", " + individualEdge[1] + ")"; //Last element, doesn't add a ", " to the end
                        }
                        else
                        {
                            tempString += "(" + individualEdge[0] + ", " + individualEdge[1] + "), ";
                            
                        }
                        EdgesExist = true;
                    }
                    catch (Exception ex)
                    {
                        //Exception should only occur if there are no edges in the graph. Exception handling isn't the most efficient way of doing it, but it works.
                    }
                }
                if (EdgesExist)
                {
                    row[1] = tempString;
                }
                else
                {
                    row[1] = "";
                }

                ListViewOfNodes.Items.Add(new ListViewItem(row));
            }
        }
        private void RevertFailedUpdate(AdjacencyList<string> inTempAdjList)
        {
            currentAdjList = inTempAdjList;
        }

        private void ShowGraphButton_Click(object sender, EventArgs e)
        {
            //Is it necessary to run the graphWindow in a new thread? It seems to function fine without doing so

            switch (ShowGraphButton.Text.ToLower())
            {
                case "show graph":
                    try
                    {
                        graphWindow.UpdateAdjList(currentAdjList);
                        graphWindow.Visible = true;
                        ShowGraphButton.Text = "Hide graph";
                    }
                    catch (Exception ex)
                    {
                        //Re-create a new graphWindow
                        //Prevents an exception caused by the graphWindow being closed by the user and no longer existing
                        graphWindow = new GraphWindow<string>();
                        graphWindow.UpdateAdjList(currentAdjList);
                        graphWindow.Visible = true;
                        ShowGraphButton.Text = "Hide graph";
                    }
                    break;

                case "hide graph":
                    graphWindow.Visible = false;
                    ShowGraphButton.Text = "Show graph";
                    break;
            }

            
        }

        private void RunAlgorithmButton_Click(object sender, EventArgs e)
        {
            if (ReLoadOriginalButton.Visible == false)
            {
                ReLoadOriginalButton.Show();
                try
                {
                    switch (AlgorithmListBox.SelectedItem)
                    {
                        case "Kruskals":
                            MSTAdjList = currentAdjList.DeepCopy();
                            KruskalsAlgorithm = new Kruskals<string>(currentAdjList.DeepCopy());
                            MST = KruskalsAlgorithm.FindMST();
                            SwitchCurrentAndSaved(KruskalsAlgorithm.GetMSTAdjList());
                            graphWindow.UpdateAdjList(currentAdjList);
                            break;

                        case "Prims":
                            //Prims is broken!
                            MSTAdjList = currentAdjList.DeepCopy();
                            PrimsAlgorithm = new Prims<string>(currentAdjList.DeepCopy());
                            PrimsAlgorithm.SetAdjList(currentAdjList);
                            MST = PrimsAlgorithm.FindMST();
                            SwitchCurrentAndSaved(PrimsAlgorithm.GetMSTAdjList());
                            graphWindow.UpdateAdjList(currentAdjList);
                            break;

                        case "Dijkstras":
                            //Dijkstras is broken!
                            Console.WriteLine("Dijkstras isn't implemented yet, sorry!");
                            DijkstrasAlgorithm = new Dijkstras<string>(currentAdjList.DeepCopy());
                            MST = DijkstrasAlgorithm.FindShortestPathLength(DijkstrasSRC.Text, DijkstrasDEST.Text);
                            SwitchCurrentAndSaved(DijkstrasAlgorithm.ReturnShortestPathGraph());
                            graphWindow.UpdateAdjList(currentAdjList);
                            break;

                        case "Cycle detection":

                            //Do a depth first search of the adjacency list, show a label that states if there is a cycle in the graph
                            //This label needs to be updated if the graph is updated, eg by loading a new graph or by adding, updating or removing nodes or edges.
                            MSTAdjList = currentAdjList.DeepCopy();
                            ContainsCyclesLabel.Text = "Contains cycles: " + currentAdjList.AreCycles(); //This updates the current adjacency list, fix it!
                            graphWindow.UpdateAdjList(currentAdjList);
                            break;

                        case "ToFromList":
                            SwitchCurrentAndSaved(currentAdjList.toAdjMatrix().ToAdjList()); //Converts the current graph to an adjacency matrix and back to prove there are no errors
                            graphWindow.UpdateAdjList(currentAdjList);
                            break;

                        case null:
                            ReLoadOriginalButton.Hide();
                            Console.WriteLine("Please select an algorithm!");
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occured");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Reload the original graph!");
                }
            }
        
            UpdateListView();
            UpdateStats();

        }
        private void SwitchCurrentAndSaved(AdjacencyList<string> inAdjList)
        {
            MSTAdjList = currentAdjList.DeepCopy();
            currentAdjList = inAdjList;

        }

        private void AlgorithmListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)AlgorithmListBox.SelectedItem == "Dijkstras")
            {
                DijkstrasSRC.Visible = true;
                DijkstrasDEST.Visible = true;
                DijkstrasSRCLabel.Visible = true;
                DijkstrasDESTLabel.Visible = true;
                MSTSizeLabel.Text = "Shortest path:";
            }
            else
            {
                DijkstrasSRC.Visible = false;
                DijkstrasDEST.Visible = false;
                DijkstrasSRCLabel.Visible = false;
                DijkstrasDESTLabel.Visible = false;
                MSTSizeLabel.Text = "Minimum spanning tree:";
            }
        }

        private void ReLoadOriginalButton_Click(object sender, EventArgs e)
        {
            currentAdjList = MSTAdjList.DeepCopy();
            ReLoadOriginalButton.Hide();
            UpdateListView();
            UpdateStats();
            graphWindow.UpdateAdjList(currentAdjList);
        }

        #endregion

        //Could change the tab-through order of controls so that tabbing through controls works not terribly

        //Adding new columns to lists in the GUI, could be useful
        //https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-display-subitems-in-columns-with-the-windows-forms-listview-control?view=netframeworkdesktop-4.8
    }
}
