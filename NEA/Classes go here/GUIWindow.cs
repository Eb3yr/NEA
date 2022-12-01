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
            saveFileDialog1 = new SaveFileDialog();
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
            saveFileDialog1.ShowDialog();
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
        }

        //Adding new columns to lists in the GUI
        //https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-display-subitems-in-columns-with-the-windows-forms-listview-control?view=netframeworkdesktop-4.8
    }
}
