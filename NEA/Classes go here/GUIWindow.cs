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
    {
        protected object currentAdjList;
        protected object savedAdjList;
        public GUIWindow()
        {
            InitializeComponent();

            //It's setuppin' time
            currentAdjList = new AdjacencyList<string>(); //Going with string for now, might add a selectable list to choose which variable you use but there isn't really much point right now
        }

        private void GUIWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void SaveToTempVar_Click(object sender, EventArgs e)
        {
            if (IsSaveToVar.Checked == true)
            {
                savedAdjList = currentAdjList;
            }
            else
            {
                //Save to local storage instead
            }
            
        }

        private void SaveAsGraphLocally_Click(object sender, EventArgs e)
        {
            SaveFileDialogue.ShowDialog();
            SaveFileDialogue.OpenFile().Close(); //Gives me an IO stream, then closes it so the program doesn't die
            //Add protection for empty file names
            //https://www.c-sharpcorner.com/article/c-sharp-write-to-file/
            
            //https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog.openfile?view=windowsdesktop-7.0
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

        private void IsSaveToVar_MouseClick(object sender, MouseEventArgs e) //DO NOT use the CheckedChange event, it'll end up generating a CheckedChange event for the other check box and cause a stack overflow
        {
            //Save to var is initially set to true to prevent these getting out of sync. Make sure this is impossible to break later, but it doesn't seem to break now
            IsSaveToLocal.Checked = !IsSaveToLocal.Checked;
        }

        private void IsSaveToLocal_MouseClick(object sender, MouseEventArgs e)
        {
            IsSaveToVar.Checked = !IsSaveToLocal.Checked;
        }

        private void IsDeleteNode_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDeleteNode.Checked == true)
            {
                UpdateAdjListButton.Text = "Delete";
            }
            else
            {
                UpdateAdjListButton.Text = "Update";
            }
        }

        private void UpdateAdjListButton_Click(object sender, EventArgs e)
        {
            if (SrcNodeTextBox.Text.Trim().Length == 0 && DestNodeTextBox.Text.Trim().Length == 0 && EdgeWeightTextBox.Text.Trim().Length == 0) //If the entered text is empty, either no characters or only whitespace
            {
                UpdateMsgLabel.Text = "Please fill all fields!";
            }
            else
            {
                //Operate normally adding/removing/updating Adjacency List using inputted data from the text boxes
            }
        }

        private void SaveFileDialogue_FileOk(object sender, CancelEventArgs e)
        {
            FilePathLabel.Text = "File path: " + SaveFileDialogue.FileName;
        }

        private void LoadFileDialogue_FileOk(object sender, CancelEventArgs e)
        {
            FilePathLabel.Text = "File path: " + LoadFileDialogue.FileName;
        }

        //Adding new columns to lists in the GUI
        //https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-display-subitems-in-columns-with-the-windows-forms-listview-control?view=netframeworkdesktop-4.8
    }
}
