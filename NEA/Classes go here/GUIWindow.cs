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
        public GUIWindow()
        {
            InitializeComponent();

            //It's setuppin' time
            currentAdjList = new AdjacencyList<string>(); //Going with string for now, other types don't currently offer any advantage
        }

        private void GUIWindow_Load(object sender, EventArgs e)
        {

        }

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
                Stream fileStream = null;
                SaveFileDialogue.ShowDialog();
                Console.WriteLine("SaveFile dialogue opened");

                fileStream = SaveFileDialogue.OpenFile(); //Gives me an IO stream, add protection for empty file names, https://www.c-sharpcorner.com/article/c-sharp-write-to-file/

                WriteFileToLocal();
                fileStream.Close(); //Otherwise files stay open, things break

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
            }
        }

        private void WriteFileToLocal()
        {
            //Write the file
        }

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
        }

        private void LoadFileDialogue_FileOk(object sender, CancelEventArgs e)
        {
            FilePathLabel.Text = "File path: " + LoadFileDialogue.FileName;
        }

        #endregion

        private void UpdateAdjListButton_Click(object sender, EventArgs e)
        {
            tempAdjList = currentAdjList; //Try-catch needs to be able to revert the graph to its previous state if something goes wrong mid-execution

            //Checks for necessary fields not being empty are the if-else statements with .Text.Trim().Length == 0
            //I could probably make it more secure by using the Checked property of the relevant tick boxes, but this is a bit easier and is dependent on the checked state of the relevant tick boxes
            switch (UpdateAdjListButton.Text)
            {
                case "Add Node": //Add node
                    if (SrcNodeTextBox.Text.Trim().Length == 0)
                    {
                        UpdateMsgLabel.Text = "Please fill all necessary fields!";
                    }
                    else
                    {
                        //Run it
                        try
                        {
                            currentAdjList.AddNode(SrcNodeTextBox.Text);
                        }
                        catch (Exception ex)
                        {
                            UpdateMsgLabel.Text = "Invalid input(s). Please use the correct data types for each field!";
                            RevertFailedUpdate(tempAdjList);
                        }
                    }
                    break;

                case "Update Node": //Update note
                    if (SrcNodeTextBox.Text.Trim().Length == 0 || DestNodeTextBox.Text.Trim().Length == 0)
                    {
                        UpdateMsgLabel.Text = "Please fill all necessary fields!";
                    }
                    else
                    {
                        //Run it
                        try
                        {

                        }
                        catch (Exception ex)
                        {
                            UpdateMsgLabel.Text = "Invalid input(s). Please use the correct data types for each field!";
                            RevertFailedUpdate(tempAdjList);
                        }
                    }
                    break;

                case "Delete Node": //Delete node
                    if (SrcNodeTextBox.Text.Trim().Length == 0)
                    {
                        UpdateMsgLabel.Text = "Please fill all necessary fields!";
                    }
                    else
                    {
                        //Run it
                        try
                        {

                        }
                        catch (Exception ex)
                        {
                            UpdateMsgLabel.Text = "Invalid input(s). Please use the correct data types for each field!";
                            RevertFailedUpdate(tempAdjList);
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
                        //Run it
                        try
                        {

                        }
                        catch (Exception ex)
                        {
                            UpdateMsgLabel.Text = "Invalid input(s). Please use the correct data types for each field!";
                            RevertFailedUpdate(tempAdjList);
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
                        //Run it
                        try
                        {

                        }
                        catch (Exception ex)
                        {
                            UpdateMsgLabel.Text = "Invalid input(s). Please use the correct data types for each field!";
                            RevertFailedUpdate(tempAdjList);
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
                        //Run it
                        try
                        {

                        }
                        catch (Exception ex)
                        {
                            UpdateMsgLabel.Text = "Invalid input(s). Please use the correct data types for each field!";
                            RevertFailedUpdate(tempAdjList);
                            //Could I add a help tooltip on which data types should be used?
                        }
                    }
                    break;
            }

            switch (CheckBoxEditNodes.Checked)
            {
                case true: //Editing nodes
                    

                case false: //Editing edges
                    switch (UpdateAdjListButton.Text)
                    {
                        
                    }
                    break;
            }

            
        }
        private void RevertFailedUpdate(AdjacencyList<string> inTempAdjList)
        {
            currentAdjList = inTempAdjList;
        }

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
                case "Add Node": //Add node
                    SrcNodeLabel.Visible = true;
                    SrcNodeTextBox.Visible = true;
                    DestNodeLabel.Text = "Destination Node Name";
                    DestNodeLabel.Visible = false;
                    DestNodeTextBox.Visible = false;
                    EdgeWeightLabel.Visible = false;
                    EdgeWeightTextBox.Visible = false;
                    break;

                case "Update Node": //Update note
                    SrcNodeLabel.Visible = true;
                    SrcNodeTextBox.Visible = true;
                    DestNodeLabel.Text = "New Node Name";
                    DestNodeLabel.Visible = true;
                    DestNodeTextBox.Visible = true;
                    EdgeWeightLabel.Visible = false;
                    EdgeWeightTextBox.Visible = false;
                    break;

                case "Delete Node": //Delete node
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

        //Adding new columns to lists in the GUI
        //https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-display-subitems-in-columns-with-the-windows-forms-listview-control?view=netframeworkdesktop-4.8
    }
}
