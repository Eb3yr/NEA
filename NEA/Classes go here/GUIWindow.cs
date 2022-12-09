using NEA.Classes_go_here;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NEA
{
    public partial class GUIWindow : Form
    { //Go through and organise methods into regions and put them in a sensible order to improve readability
        protected AdjacencyList<string> currentAdjList;
        protected AdjacencyList<string> savedAdjList;
        protected AdjacencyList<string> tempAdjList;
        protected GraphWindow<string> graphWindow;
        public GUIWindow()
        {
            InitializeComponent();

            //It's setuppin' time
            currentAdjList = new AdjacencyList<string>(); //Going with string for now, other types don't currently offer any advantage
            graphWindow = new GraphWindow<string>();
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
                savedAdjList = currentAdjList;
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
                Console.WriteLine("SaveFile dialogue opened");

                SaveFileDialogue.OpenFile().Close(); //Gives me an IO stream, add protection for empty file names, https://www.c-sharpcorner.com/article/c-sharp-write-to-file/

                //This writes even if the dialogue was cancelled out of!
                try
                {
                    WriteFileToLocal();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error writing to file! Add an error message somewhere on the form later");
                }
                //fileStream.Close(); //Otherwise files stay open, things break

                //https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog.openfile?view=windowsdesktop-7.0
            }
        }

        private void LoadGraph_Click(object sender, EventArgs e)
        {
            if (IsSaveToVar.Checked == true)
            {
                if (savedAdjList != null) //if instantiated
                {
                    currentAdjList = savedAdjList;
                }
                else
                {
                    //Make an error message appear!
                }
                //Doesn't do anything if there's nothing in the saved adjacency list to prevent accidental data loss
            }
            else
            {
                LoadFileDialogue.ShowDialog();
                LoadFileDialogue.OpenFile().Close();

                LoadFromFile();
            }
        }
        private void LoadFromFile()
        {
            string[] fileData = File.ReadAllLines(LoadFileDialogue.FileName);

        }
        private void WriteFileToLocal()
        {
            Console.WriteLine("\nwriting:");
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

            


            File.WriteAllLines(SaveFileDialogue.FileName, listOfLines.ToArray()); //Will overwrite pre-existing files of this name. Need to test if it overwrites or just appends
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
            //WriteFileToLocal();
        }

        private void LoadFileDialogue_FileOk(object sender, CancelEventArgs e)
        {
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
                        }
                        else
                        {
                            try
                            {
                                currentAdjList.AddNode(SrcNodeTextBox.Text);
                            }
                            catch (Exception ex)
                            {
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
                        }
                        else
                        {
                            try
                            {
                                currentAdjList.EditNode(SrcNodeTextBox.Text, DestNodeTextBox.Text);
                            }
                            catch (Exception ex)
                            {
                                UpdateMsgLabel.Text = "Invalid input(s)";
                                RevertFailedUpdate(tempAdjList);
                                success = false;
                            }
                        }
                        break;

                    case "Delete Node":
                        if (SrcNodeTextBox.Text.Trim().Length == 0)
                        {
                            UpdateMsgLabel.Text = "Please fill all necessary fields!";
                        }
                        else
                        {
                            try
                            {
                                currentAdjList.RemoveNode(SrcNodeTextBox.Text);
                            }
                            catch (Exception ex)
                            {
                                UpdateMsgLabel.Text = "Invalid input(s)";
                                RevertFailedUpdate(tempAdjList);
                                success = false;
                            }
                        }
                        break;

                    case "Add Edge":
                        if (SrcNodeTextBox.Text.Trim().Length == 0 || DestNodeTextBox.Text.Trim().Length == 0 || EdgeWeightTextBox.Text.Trim().Length == 0)
                        {
                            UpdateMsgLabel.Text = "Please fill all necessary fields!";
                        }
                        else
                        {
                            try
                            {
                                currentAdjList.AddEdge(SrcNodeTextBox.Text, DestNodeTextBox.Text, double.Parse(EdgeWeightTextBox.Text), IsDirectedCheckBox.Checked);
                            }
                            catch (Exception ex)
                            {
                                UpdateMsgLabel.Text = "Invalid input(s)";
                                RevertFailedUpdate(tempAdjList);
                                success = false;
                            }
                        }
                        break;

                    case "Update Edge":
                        if (SrcNodeTextBox.Text.Trim().Length == 0 || DestNodeTextBox.Text.Trim().Length == 0 || EdgeWeightTextBox.Text.Trim().Length == 0)
                        {
                            UpdateMsgLabel.Text = "Please fill all necessary fields!";
                        }
                        else
                        {
                            try
                            {
                                currentAdjList.EditEdge(SrcNodeTextBox.Text, DestNodeTextBox.Text, double.Parse(EdgeWeightTextBox.Text));
                            }
                            catch (Exception ex)
                            {
                                UpdateMsgLabel.Text = "Invalid input(s)";
                                RevertFailedUpdate(tempAdjList);
                                success = false;
                            }
                        }
                        break;

                    case "Delete Ege":
                        if (SrcNodeTextBox.Text.Trim().Length == 0 || DestNodeTextBox.Text.Trim().Length == 0)
                        {
                            UpdateMsgLabel.Text = "Please fill all necessary fields!";
                        }
                        else
                        {
                            try
                            {
                                currentAdjList.RemoveEdge(SrcNodeTextBox.Text, DestNodeTextBox.Text, IsDirectedCheckBox.Checked);
                            }
                            catch (Exception ex)
                            {
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
            }

            UpdateListView();
        }
        private void UpdateListView()
        {
            //Make listview show the graph in all of its tabular glory
        }
        private void RevertFailedUpdate(AdjacencyList<string> inTempAdjList)
        {
            currentAdjList = inTempAdjList;
        }

        private void ShowGraphButon_Click(object sender, EventArgs e)
        {
            switch (ShowGraphButton.Text)
            {
                case "Show Graph":
                    graphWindow.UpdateAdjList(currentAdjList);
                    graphWindow.Visible = true;
                    ShowGraphButton.Text = "Hide Graph";
                    break;

                case "Hide Graph":
                    graphWindow.Visible = false;
                    ShowGraphButton.Text = "Show Graph";
                    break;
            }
        }

        #endregion

        //Could change the tab-through order of controls so that tabbing through controls works not terribly

        //Adding new columns to lists in the GUI, could be useful
        //https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-display-subitems-in-columns-with-the-windows-forms-listview-control?view=netframeworkdesktop-4.8
    }
}
