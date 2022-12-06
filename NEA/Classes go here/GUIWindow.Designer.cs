namespace NEA
{
    partial class GUIWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ColumnHeader DestNodesColumn;
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "a",
            "wgawghagawgawg"}, -1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "b",
            "A, 17",
            "D, 14"}, -1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("c");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "d",
            "A, 3",
            "B, 6",
            "C. 4"}, -1);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("e");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("f");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("g");
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.CheckBoxHasWeight = new System.Windows.Forms.CheckBox();
            this.CheckBoxIsDirected = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ListViewOfNodes = new System.Windows.Forms.ListView();
            this.SrcNodeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SaveGraph = new System.Windows.Forms.Button();
            this.LoadGraph = new System.Windows.Forms.Button();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.SaveAsGraphLocally = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.IsSaveToVar = new System.Windows.Forms.CheckBox();
            this.IsSaveToLocal = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.UpdateMsgLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.EdgeWeightTextBox = new System.Windows.Forms.TextBox();
            this.DestNodeTextBox = new System.Windows.Forms.TextBox();
            this.SrcNodeTextBox = new System.Windows.Forms.TextBox();
            this.SaveFileDialogue = new System.Windows.Forms.SaveFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.UpdateAdjListButton = new System.Windows.Forms.Button();
            this.LoadFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.CheckBoxEditEdges = new System.Windows.Forms.CheckBox();
            this.CheckBoxEditNodes = new System.Windows.Forms.CheckBox();
            this.CheckBoxDelete = new System.Windows.Forms.CheckBox();
            this.CheckBoxUpdate = new System.Windows.Forms.CheckBox();
            this.CheckBoxAdd = new System.Windows.Forms.CheckBox();
            DestNodesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // DestNodesColumn
            // 
            DestNodesColumn.Text = "Adjacent Nodes";
            DestNodesColumn.Width = 251;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Kruskals (NOT CURRENTLY FUNCTIONAL)",
            "Prims",
            "Dijkstras (NOT CURRENTLY FUNCTIONAL)"});
            this.listBox1.Location = new System.Drawing.Point(561, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(227, 43);
            this.listBox1.TabIndex = 0;
            // 
            // CheckBoxHasWeight
            // 
            this.CheckBoxHasWeight.AutoSize = true;
            this.CheckBoxHasWeight.Location = new System.Drawing.Point(561, 83);
            this.CheckBoxHasWeight.Name = "CheckBoxHasWeight";
            this.CheckBoxHasWeight.Size = new System.Drawing.Size(109, 17);
            this.CheckBoxHasWeight.TabIndex = 3;
            this.CheckBoxHasWeight.Text = "Graph has weight";
            this.CheckBoxHasWeight.UseVisualStyleBackColor = true;
            // 
            // CheckBoxIsDirected
            // 
            this.CheckBoxIsDirected.AutoSize = true;
            this.CheckBoxIsDirected.Location = new System.Drawing.Point(561, 106);
            this.CheckBoxIsDirected.Name = "CheckBoxIsDirected";
            this.CheckBoxIsDirected.Size = new System.Drawing.Size(106, 17);
            this.CheckBoxIsDirected.TabIndex = 4;
            this.CheckBoxIsDirected.Text = "Graph is directed";
            this.CheckBoxIsDirected.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(472, 600);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // ListViewOfNodes
            // 
            this.ListViewOfNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SrcNodeColumn,
            DestNodesColumn});
            this.ListViewOfNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewOfNodes.HideSelection = false;
            listViewItem8.StateImageIndex = 0;
            listViewItem9.StateImageIndex = 0;
            listViewItem10.StateImageIndex = 0;
            listViewItem11.StateImageIndex = 0;
            listViewItem12.StateImageIndex = 0;
            listViewItem13.StateImageIndex = 0;
            listViewItem14.StateImageIndex = 0;
            this.ListViewOfNodes.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14});
            this.ListViewOfNodes.Location = new System.Drawing.Point(15, 34);
            this.ListViewOfNodes.MultiSelect = false;
            this.ListViewOfNodes.Name = "ListViewOfNodes";
            this.ListViewOfNodes.Size = new System.Drawing.Size(391, 97);
            this.ListViewOfNodes.TabIndex = 9;
            this.ListViewOfNodes.UseCompatibleStateImageBehavior = false;
            this.ListViewOfNodes.View = System.Windows.Forms.View.Details;
            // 
            // SrcNodeColumn
            // 
            this.SrcNodeColumn.Text = "Nodes";
            this.SrcNodeColumn.Width = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Graph controls";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(469, 561);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "I can show and hide stuff depending on if the header is ticked or not, eg editing" +
    " nodes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 584);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(438, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "can use this combo box for selecting the variable type to use for the name, if I " +
    "have the time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 545);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(421, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Make sure I\'m using labels not text boxes (stuff can be entered in them) wher app" +
    "licable!";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(558, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Algorithm list";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(558, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Number of nodes:";
            // 
            // SaveGraph
            // 
            this.SaveGraph.Location = new System.Drawing.Point(16, 359);
            this.SaveGraph.Name = "SaveGraph";
            this.SaveGraph.Size = new System.Drawing.Size(106, 23);
            this.SaveGraph.TabIndex = 23;
            this.SaveGraph.Text = "Save graph";
            this.SaveGraph.UseVisualStyleBackColor = true;
            this.SaveGraph.Click += new System.EventHandler(this.SaveToTempVar_Click);
            // 
            // LoadGraph
            // 
            this.LoadGraph.Location = new System.Drawing.Point(16, 388);
            this.LoadGraph.Name = "LoadGraph";
            this.LoadGraph.Size = new System.Drawing.Size(106, 23);
            this.LoadGraph.TabIndex = 24;
            this.LoadGraph.Text = "Load Graph";
            this.LoadGraph.UseVisualStyleBackColor = true;
            this.LoadGraph.Click += new System.EventHandler(this.LoadGraph_Click);
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.AutoSize = true;
            this.FilePathLabel.Location = new System.Drawing.Point(94, 422);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(50, 13);
            this.FilePathLabel.TabIndex = 25;
            this.FilePathLabel.Text = "File path:";
            // 
            // SaveAsGraphLocally
            // 
            this.SaveAsGraphLocally.Location = new System.Drawing.Point(16, 417);
            this.SaveAsGraphLocally.Name = "SaveAsGraphLocally";
            this.SaveAsGraphLocally.Size = new System.Drawing.Size(72, 23);
            this.SaveAsGraphLocally.TabIndex = 26;
            this.SaveAsGraphLocally.Text = "Save as...";
            this.SaveAsGraphLocally.UseVisualStyleBackColor = true;
            this.SaveAsGraphLocally.Click += new System.EventHandler(this.SaveAsGraphLocally_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(505, 398);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(334, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Make a selectable list of graphs (adjlists) to select and edit individually";
            // 
            // IsSaveToVar
            // 
            this.IsSaveToVar.AutoSize = true;
            this.IsSaveToVar.Checked = true;
            this.IsSaveToVar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsSaveToVar.Location = new System.Drawing.Point(141, 359);
            this.IsSaveToVar.Name = "IsSaveToVar";
            this.IsSaveToVar.Size = new System.Drawing.Size(103, 17);
            this.IsSaveToVar.TabIndex = 29;
            this.IsSaveToVar.Text = "Save to variable";
            this.IsSaveToVar.UseVisualStyleBackColor = true;
            this.IsSaveToVar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IsSaveToVar_MouseClick);
            // 
            // IsSaveToLocal
            // 
            this.IsSaveToLocal.AutoSize = true;
            this.IsSaveToLocal.Location = new System.Drawing.Point(141, 382);
            this.IsSaveToLocal.Name = "IsSaveToLocal";
            this.IsSaveToLocal.Size = new System.Drawing.Size(126, 17);
            this.IsSaveToLocal.TabIndex = 30;
            this.IsSaveToLocal.Text = "Save to local storage";
            this.IsSaveToLocal.UseVisualStyleBackColor = true;
            this.IsSaveToLocal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IsSaveToLocal_MouseClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Source node name";
            // 
            // UpdateMsgLabel
            // 
            this.UpdateMsgLabel.AutoSize = true;
            this.UpdateMsgLabel.Location = new System.Drawing.Point(130, 225);
            this.UpdateMsgLabel.Name = "UpdateMsgLabel";
            this.UpdateMsgLabel.Size = new System.Drawing.Size(196, 13);
            this.UpdateMsgLabel.TabIndex = 32;
            this.UpdateMsgLabel.Text = "This says what the previous comand did";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Edge weight";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 166);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Destination node name";
            // 
            // EdgeWeightTextBox
            // 
            this.EdgeWeightTextBox.Location = new System.Drawing.Point(133, 189);
            this.EdgeWeightTextBox.Name = "EdgeWeightTextBox";
            this.EdgeWeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.EdgeWeightTextBox.TabIndex = 35;
            // 
            // DestNodeTextBox
            // 
            this.DestNodeTextBox.Location = new System.Drawing.Point(133, 163);
            this.DestNodeTextBox.Name = "DestNodeTextBox";
            this.DestNodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.DestNodeTextBox.TabIndex = 36;
            // 
            // SrcNodeTextBox
            // 
            this.SrcNodeTextBox.Location = new System.Drawing.Point(133, 137);
            this.SrcNodeTextBox.Name = "SrcNodeTextBox";
            this.SrcNodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.SrcNodeTextBox.TabIndex = 37;
            // 
            // SaveFileDialogue
            // 
            this.SaveFileDialogue.DefaultExt = "GRAPH";
            this.SaveFileDialogue.FileName = "myGraph.GRAPH";
            this.SaveFileDialogue.Filter = ".GRAPH|*.GRAPH";
            this.SaveFileDialogue.RestoreDirectory = true;
            this.SaveFileDialogue.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialogue_FileOk);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(558, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Minimum Spanning Tree: ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(558, 166);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Number of edges: ";
            // 
            // UpdateAdjListButton
            // 
            this.UpdateAdjListButton.Location = new System.Drawing.Point(25, 220);
            this.UpdateAdjListButton.Name = "UpdateAdjListButton";
            this.UpdateAdjListButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateAdjListButton.TabIndex = 43;
            this.UpdateAdjListButton.Text = "Update";
            this.UpdateAdjListButton.UseVisualStyleBackColor = true;
            this.UpdateAdjListButton.Click += new System.EventHandler(this.UpdateAdjListButton_Click);
            // 
            // LoadFileDialogue
            // 
            this.LoadFileDialogue.DefaultExt = "GRAPH";
            this.LoadFileDialogue.FileName = "myGraph.GRAPH";
            this.LoadFileDialogue.Filter = ".GRAPH|*.GRAPH";
            this.LoadFileDialogue.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadFileDialogue_FileOk);
            // 
            // CheckBoxEditEdges
            // 
            this.CheckBoxEditEdges.AutoSize = true;
            this.CheckBoxEditEdges.Location = new System.Drawing.Point(328, 166);
            this.CheckBoxEditEdges.Name = "CheckBoxEditEdges";
            this.CheckBoxEditEdges.Size = new System.Drawing.Size(77, 17);
            this.CheckBoxEditEdges.TabIndex = 48;
            this.CheckBoxEditEdges.Text = "Edit Edges";
            this.CheckBoxEditEdges.UseVisualStyleBackColor = true;
            this.CheckBoxEditEdges.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckBoxEditEdges_MouseClick);
            // 
            // CheckBoxEditNodes
            // 
            this.CheckBoxEditNodes.AutoSize = true;
            this.CheckBoxEditNodes.Checked = true;
            this.CheckBoxEditNodes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxEditNodes.Location = new System.Drawing.Point(328, 139);
            this.CheckBoxEditNodes.Name = "CheckBoxEditNodes";
            this.CheckBoxEditNodes.Size = new System.Drawing.Size(78, 17);
            this.CheckBoxEditNodes.TabIndex = 47;
            this.CheckBoxEditNodes.Text = "Edit Nodes";
            this.CheckBoxEditNodes.UseVisualStyleBackColor = true;
            this.CheckBoxEditNodes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckBoxEditNodes_MouseClick);
            // 
            // CheckBoxDelete
            // 
            this.CheckBoxDelete.AutoSize = true;
            this.CheckBoxDelete.Location = new System.Drawing.Point(261, 192);
            this.CheckBoxDelete.Name = "CheckBoxDelete";
            this.CheckBoxDelete.Size = new System.Drawing.Size(57, 17);
            this.CheckBoxDelete.TabIndex = 46;
            this.CheckBoxDelete.Text = "Delete";
            this.CheckBoxDelete.UseVisualStyleBackColor = true;
            this.CheckBoxDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckBoxDelete_MouseClick);
            // 
            // CheckBoxUpdate
            // 
            this.CheckBoxUpdate.AutoSize = true;
            this.CheckBoxUpdate.Location = new System.Drawing.Point(261, 166);
            this.CheckBoxUpdate.Name = "CheckBoxUpdate";
            this.CheckBoxUpdate.Size = new System.Drawing.Size(61, 17);
            this.CheckBoxUpdate.TabIndex = 45;
            this.CheckBoxUpdate.Text = "Update";
            this.CheckBoxUpdate.UseVisualStyleBackColor = true;
            this.CheckBoxUpdate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckBoxUpdate_MouseClick);
            // 
            // CheckBoxAdd
            // 
            this.CheckBoxAdd.AutoSize = true;
            this.CheckBoxAdd.Checked = true;
            this.CheckBoxAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxAdd.Location = new System.Drawing.Point(261, 140);
            this.CheckBoxAdd.Name = "CheckBoxAdd";
            this.CheckBoxAdd.Size = new System.Drawing.Size(48, 17);
            this.CheckBoxAdd.TabIndex = 44;
            this.CheckBoxAdd.Text = "Add ";
            this.CheckBoxAdd.UseVisualStyleBackColor = true;
            this.CheckBoxAdd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckBoxAdd_MouseClick);
            // 
            // GUIWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 639);
            this.Controls.Add(this.CheckBoxEditEdges);
            this.Controls.Add(this.CheckBoxEditNodes);
            this.Controls.Add(this.CheckBoxDelete);
            this.Controls.Add(this.CheckBoxUpdate);
            this.Controls.Add(this.CheckBoxAdd);
            this.Controls.Add(this.UpdateAdjListButton);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SrcNodeTextBox);
            this.Controls.Add(this.DestNodeTextBox);
            this.Controls.Add(this.EdgeWeightTextBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.UpdateMsgLabel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.IsSaveToLocal);
            this.Controls.Add(this.IsSaveToVar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SaveAsGraphLocally);
            this.Controls.Add(this.FilePathLabel);
            this.Controls.Add(this.LoadGraph);
            this.Controls.Add(this.SaveGraph);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListViewOfNodes);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.CheckBoxIsDirected);
            this.Controls.Add(this.CheckBoxHasWeight);
            this.Controls.Add(this.listBox1);
            this.Name = "GUIWindow";
            this.Text = "GUIWindow";
            this.Load += new System.EventHandler(this.GUIWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox CheckBoxHasWeight;
        private System.Windows.Forms.CheckBox CheckBoxIsDirected;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView ListViewOfNodes;
        private System.Windows.Forms.ColumnHeader SrcNodeColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SaveGraph;
        private System.Windows.Forms.Button LoadGraph;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.Button SaveAsGraphLocally;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox IsSaveToVar;
        private System.Windows.Forms.CheckBox IsSaveToLocal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label UpdateMsgLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox EdgeWeightTextBox;
        private System.Windows.Forms.TextBox DestNodeTextBox;
        private System.Windows.Forms.TextBox SrcNodeTextBox;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button UpdateAdjListButton;
        private System.Windows.Forms.OpenFileDialog LoadFileDialogue;
        private System.Windows.Forms.CheckBox CheckBoxEditEdges;
        private System.Windows.Forms.CheckBox CheckBoxEditNodes;
        private System.Windows.Forms.CheckBox CheckBoxDelete;
        private System.Windows.Forms.CheckBox CheckBoxUpdate;
        private System.Windows.Forms.CheckBox CheckBoxAdd;
    }
}