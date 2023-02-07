namespace NEA.Classes
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
            this.DestNodesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AlgorithmListBox = new System.Windows.Forms.ListBox();
            this.IsEdgeDirectedCheckBox = new System.Windows.Forms.CheckBox();
            this.ListViewOfNodes = new System.Windows.Forms.ListView();
            this.SrcNodeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NoOfNodesLabel = new System.Windows.Forms.Label();
            this.SaveGraph = new System.Windows.Forms.Button();
            this.LoadGraph = new System.Windows.Forms.Button();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.SaveAsGraphLocally = new System.Windows.Forms.Button();
            this.IsSaveToVar = new System.Windows.Forms.CheckBox();
            this.IsSaveToLocal = new System.Windows.Forms.CheckBox();
            this.SrcNodeLabel = new System.Windows.Forms.Label();
            this.UpdateMsgLabel = new System.Windows.Forms.Label();
            this.EdgeWeightLabel = new System.Windows.Forms.Label();
            this.DestNodeLabel = new System.Windows.Forms.Label();
            this.EdgeWeightTextBox = new System.Windows.Forms.TextBox();
            this.DestNodeTextBox = new System.Windows.Forms.TextBox();
            this.SrcNodeTextBox = new System.Windows.Forms.TextBox();
            this.SaveFileDialogue = new System.Windows.Forms.SaveFileDialog();
            this.MSTSizeLabel = new System.Windows.Forms.Label();
            this.NoOfEdgesLabel = new System.Windows.Forms.Label();
            this.UpdateAdjListButton = new System.Windows.Forms.Button();
            this.LoadFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.CheckBoxEditEdges = new System.Windows.Forms.CheckBox();
            this.CheckBoxEditNodes = new System.Windows.Forms.CheckBox();
            this.CheckBoxDelete = new System.Windows.Forms.CheckBox();
            this.CheckBoxUpdate = new System.Windows.Forms.CheckBox();
            this.CheckBoxAdd = new System.Windows.Forms.CheckBox();
            this.ShowGraphButton = new System.Windows.Forms.Button();
            this.RunAlgorithmButton = new System.Windows.Forms.Button();
            this.ReLoadOriginalButton = new System.Windows.Forms.Button();
            this.ContainsCyclesLabel = new System.Windows.Forms.Label();
            this.DijkstrasSRC = new System.Windows.Forms.TextBox();
            this.DijkstrasDEST = new System.Windows.Forms.TextBox();
            this.DijkstrasSRCLabel = new System.Windows.Forms.Label();
            this.DijkstrasDESTLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DestNodesColumn
            // 
            this.DestNodesColumn.Text = "Adjacent nodes";
            this.DestNodesColumn.Width = 296;
            // 
            // AlgorithmListBox
            // 
            this.AlgorithmListBox.FormattingEnabled = true;
            this.AlgorithmListBox.Items.AddRange(new object[] {
            "Kruskals",
            "Prims",
            "Dijkstras",
            "Cycle detection",
            "ToFromList"});
            this.AlgorithmListBox.Location = new System.Drawing.Point(561, 34);
            this.AlgorithmListBox.Name = "AlgorithmListBox";
            this.AlgorithmListBox.Size = new System.Drawing.Size(227, 56);
            this.AlgorithmListBox.TabIndex = 0;
            this.AlgorithmListBox.SelectedIndexChanged += new System.EventHandler(this.AlgorithmListBox_SelectedIndexChanged);
            // 
            // IsEdgeDirectedCheckBox
            // 
            this.IsEdgeDirectedCheckBox.AutoSize = true;
            this.IsEdgeDirectedCheckBox.Location = new System.Drawing.Point(328, 192);
            this.IsEdgeDirectedCheckBox.Name = "IsEdgeDirectedCheckBox";
            this.IsEdgeDirectedCheckBox.Size = new System.Drawing.Size(102, 17);
            this.IsEdgeDirectedCheckBox.TabIndex = 4;
            this.IsEdgeDirectedCheckBox.Text = "Edge is directed";
            this.IsEdgeDirectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // ListViewOfNodes
            // 
            this.ListViewOfNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SrcNodeColumn,
            this.DestNodesColumn});
            this.ListViewOfNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewOfNodes.HideSelection = false;
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
            this.SrcNodeColumn.Width = 91;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(558, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Algorithm list";
            // 
            // NoOfNodesLabel
            // 
            this.NoOfNodesLabel.AutoSize = true;
            this.NoOfNodesLabel.Location = new System.Drawing.Point(558, 118);
            this.NoOfNodesLabel.Name = "NoOfNodesLabel";
            this.NoOfNodesLabel.Size = new System.Drawing.Size(91, 13);
            this.NoOfNodesLabel.TabIndex = 21;
            this.NoOfNodesLabel.Text = "Number of nodes:";
            // 
            // SaveGraph
            // 
            this.SaveGraph.Location = new System.Drawing.Point(16, 359);
            this.SaveGraph.Name = "SaveGraph";
            this.SaveGraph.Size = new System.Drawing.Size(106, 23);
            this.SaveGraph.TabIndex = 23;
            this.SaveGraph.Text = "Save graph";
            this.SaveGraph.UseVisualStyleBackColor = true;
            this.SaveGraph.Click += new System.EventHandler(this.SaveGraph_Click);
            // 
            // LoadGraph
            // 
            this.LoadGraph.Location = new System.Drawing.Point(16, 388);
            this.LoadGraph.Name = "LoadGraph";
            this.LoadGraph.Size = new System.Drawing.Size(106, 23);
            this.LoadGraph.TabIndex = 24;
            this.LoadGraph.Text = "Load graph";
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
            // SrcNodeLabel
            // 
            this.SrcNodeLabel.AutoSize = true;
            this.SrcNodeLabel.Location = new System.Drawing.Point(13, 140);
            this.SrcNodeLabel.Name = "SrcNodeLabel";
            this.SrcNodeLabel.Size = new System.Drawing.Size(97, 13);
            this.SrcNodeLabel.TabIndex = 31;
            this.SrcNodeLabel.Text = "Source node name";
            // 
            // UpdateMsgLabel
            // 
            this.UpdateMsgLabel.AutoSize = true;
            this.UpdateMsgLabel.Location = new System.Drawing.Point(132, 225);
            this.UpdateMsgLabel.Name = "UpdateMsgLabel";
            this.UpdateMsgLabel.Size = new System.Drawing.Size(215, 13);
            this.UpdateMsgLabel.TabIndex = 32;
            this.UpdateMsgLabel.Text = "This will state what the previous comand did";
            // 
            // EdgeWeightLabel
            // 
            this.EdgeWeightLabel.AutoSize = true;
            this.EdgeWeightLabel.Location = new System.Drawing.Point(12, 192);
            this.EdgeWeightLabel.Name = "EdgeWeightLabel";
            this.EdgeWeightLabel.Size = new System.Drawing.Size(66, 13);
            this.EdgeWeightLabel.TabIndex = 33;
            this.EdgeWeightLabel.Text = "Edge weight";
            this.EdgeWeightLabel.Visible = false;
            // 
            // DestNodeLabel
            // 
            this.DestNodeLabel.AutoSize = true;
            this.DestNodeLabel.Location = new System.Drawing.Point(13, 166);
            this.DestNodeLabel.Name = "DestNodeLabel";
            this.DestNodeLabel.Size = new System.Drawing.Size(116, 13);
            this.DestNodeLabel.TabIndex = 34;
            this.DestNodeLabel.Text = "Destination node name";
            this.DestNodeLabel.Visible = false;
            // 
            // EdgeWeightTextBox
            // 
            this.EdgeWeightTextBox.Location = new System.Drawing.Point(135, 189);
            this.EdgeWeightTextBox.Name = "EdgeWeightTextBox";
            this.EdgeWeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.EdgeWeightTextBox.TabIndex = 35;
            this.EdgeWeightTextBox.Visible = false;
            // 
            // DestNodeTextBox
            // 
            this.DestNodeTextBox.Location = new System.Drawing.Point(135, 163);
            this.DestNodeTextBox.Name = "DestNodeTextBox";
            this.DestNodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.DestNodeTextBox.TabIndex = 36;
            this.DestNodeTextBox.Visible = false;
            // 
            // SrcNodeTextBox
            // 
            this.SrcNodeTextBox.Location = new System.Drawing.Point(135, 137);
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
            // MSTSizeLabel
            // 
            this.MSTSizeLabel.AutoSize = true;
            this.MSTSizeLabel.Location = new System.Drawing.Point(558, 192);
            this.MSTSizeLabel.Name = "MSTSizeLabel";
            this.MSTSizeLabel.Size = new System.Drawing.Size(121, 13);
            this.MSTSizeLabel.TabIndex = 41;
            this.MSTSizeLabel.Text = "Minimum spanning tree: ";
            // 
            // NoOfEdgesLabel
            // 
            this.NoOfEdgesLabel.AutoSize = true;
            this.NoOfEdgesLabel.Location = new System.Drawing.Point(558, 144);
            this.NoOfEdgesLabel.Name = "NoOfEdgesLabel";
            this.NoOfEdgesLabel.Size = new System.Drawing.Size(94, 13);
            this.NoOfEdgesLabel.TabIndex = 42;
            this.NoOfEdgesLabel.Text = "Number of edges: ";
            // 
            // UpdateAdjListButton
            // 
            this.UpdateAdjListButton.Location = new System.Drawing.Point(25, 220);
            this.UpdateAdjListButton.Name = "UpdateAdjListButton";
            this.UpdateAdjListButton.Size = new System.Drawing.Size(85, 23);
            this.UpdateAdjListButton.TabIndex = 43;
            this.UpdateAdjListButton.Text = "Add node";
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
            // ShowGraphButton
            // 
            this.ShowGraphButton.Location = new System.Drawing.Point(25, 273);
            this.ShowGraphButton.Name = "ShowGraphButton";
            this.ShowGraphButton.Size = new System.Drawing.Size(85, 23);
            this.ShowGraphButton.TabIndex = 49;
            this.ShowGraphButton.Text = "Show graph";
            this.ShowGraphButton.UseVisualStyleBackColor = true;
            this.ShowGraphButton.Click += new System.EventHandler(this.ShowGraphButton_Click);
            // 
            // RunAlgorithmButton
            // 
            this.RunAlgorithmButton.Location = new System.Drawing.Point(561, 214);
            this.RunAlgorithmButton.Name = "RunAlgorithmButton";
            this.RunAlgorithmButton.Size = new System.Drawing.Size(100, 23);
            this.RunAlgorithmButton.TabIndex = 52;
            this.RunAlgorithmButton.Text = "Run algorithm";
            this.RunAlgorithmButton.UseVisualStyleBackColor = true;
            this.RunAlgorithmButton.Click += new System.EventHandler(this.RunAlgorithmButton_Click);
            // 
            // ReLoadOriginalButton
            // 
            this.ReLoadOriginalButton.Location = new System.Drawing.Point(561, 244);
            this.ReLoadOriginalButton.Name = "ReLoadOriginalButton";
            this.ReLoadOriginalButton.Size = new System.Drawing.Size(100, 23);
            this.ReLoadOriginalButton.TabIndex = 55;
            this.ReLoadOriginalButton.Text = "Re-load original";
            this.ReLoadOriginalButton.UseVisualStyleBackColor = true;
            this.ReLoadOriginalButton.Visible = false;
            this.ReLoadOriginalButton.Click += new System.EventHandler(this.ReLoadOriginalButton_Click);
            // 
            // ContainsCyclesLabel
            // 
            this.ContainsCyclesLabel.AutoSize = true;
            this.ContainsCyclesLabel.Location = new System.Drawing.Point(558, 169);
            this.ContainsCyclesLabel.Name = "ContainsCyclesLabel";
            this.ContainsCyclesLabel.Size = new System.Drawing.Size(87, 13);
            this.ContainsCyclesLabel.TabIndex = 57;
            this.ContainsCyclesLabel.Text = "Contains cycles: ";
            // 
            // DijkstrasSRC
            // 
            this.DijkstrasSRC.Location = new System.Drawing.Point(651, 293);
            this.DijkstrasSRC.Name = "DijkstrasSRC";
            this.DijkstrasSRC.Size = new System.Drawing.Size(100, 20);
            this.DijkstrasSRC.TabIndex = 58;
            this.DijkstrasSRC.Visible = false;
            // 
            // DijkstrasDEST
            // 
            this.DijkstrasDEST.Location = new System.Drawing.Point(651, 319);
            this.DijkstrasDEST.Name = "DijkstrasDEST";
            this.DijkstrasDEST.Size = new System.Drawing.Size(100, 20);
            this.DijkstrasDEST.TabIndex = 59;
            this.DijkstrasDEST.Visible = false;
            // 
            // DijkstrasSRCLabel
            // 
            this.DijkstrasSRCLabel.AutoSize = true;
            this.DijkstrasSRCLabel.Location = new System.Drawing.Point(558, 296);
            this.DijkstrasSRCLabel.Name = "DijkstrasSRCLabel";
            this.DijkstrasSRCLabel.Size = new System.Drawing.Size(68, 13);
            this.DijkstrasSRCLabel.TabIndex = 60;
            this.DijkstrasSRCLabel.Text = "Source node";
            this.DijkstrasSRCLabel.Visible = false;
            // 
            // DijkstrasDESTLabel
            // 
            this.DijkstrasDESTLabel.AutoSize = true;
            this.DijkstrasDESTLabel.Location = new System.Drawing.Point(558, 322);
            this.DijkstrasDESTLabel.Name = "DijkstrasDESTLabel";
            this.DijkstrasDESTLabel.Size = new System.Drawing.Size(87, 13);
            this.DijkstrasDESTLabel.TabIndex = 61;
            this.DijkstrasDESTLabel.Text = "Destination node";
            this.DijkstrasDESTLabel.Visible = false;
            // 
            // GUIWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 483);
            this.Controls.Add(this.DijkstrasDESTLabel);
            this.Controls.Add(this.DijkstrasSRCLabel);
            this.Controls.Add(this.DijkstrasDEST);
            this.Controls.Add(this.DijkstrasSRC);
            this.Controls.Add(this.ContainsCyclesLabel);
            this.Controls.Add(this.ReLoadOriginalButton);
            this.Controls.Add(this.RunAlgorithmButton);
            this.Controls.Add(this.ShowGraphButton);
            this.Controls.Add(this.CheckBoxEditEdges);
            this.Controls.Add(this.CheckBoxEditNodes);
            this.Controls.Add(this.CheckBoxDelete);
            this.Controls.Add(this.CheckBoxUpdate);
            this.Controls.Add(this.CheckBoxAdd);
            this.Controls.Add(this.UpdateAdjListButton);
            this.Controls.Add(this.NoOfEdgesLabel);
            this.Controls.Add(this.MSTSizeLabel);
            this.Controls.Add(this.SrcNodeTextBox);
            this.Controls.Add(this.DestNodeTextBox);
            this.Controls.Add(this.EdgeWeightTextBox);
            this.Controls.Add(this.DestNodeLabel);
            this.Controls.Add(this.EdgeWeightLabel);
            this.Controls.Add(this.UpdateMsgLabel);
            this.Controls.Add(this.SrcNodeLabel);
            this.Controls.Add(this.IsSaveToLocal);
            this.Controls.Add(this.IsSaveToVar);
            this.Controls.Add(this.SaveAsGraphLocally);
            this.Controls.Add(this.FilePathLabel);
            this.Controls.Add(this.LoadGraph);
            this.Controls.Add(this.SaveGraph);
            this.Controls.Add(this.NoOfNodesLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListViewOfNodes);
            this.Controls.Add(this.IsEdgeDirectedCheckBox);
            this.Controls.Add(this.AlgorithmListBox);
            this.Name = "GUIWindow";
            this.Text = "GUIWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AlgorithmListBox;
        private System.Windows.Forms.CheckBox IsEdgeDirectedCheckBox;
        private System.Windows.Forms.ListView ListViewOfNodes;
        private System.Windows.Forms.ColumnHeader SrcNodeColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label NoOfNodesLabel;
        private System.Windows.Forms.Button SaveGraph;
        private System.Windows.Forms.Button LoadGraph;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.Button SaveAsGraphLocally;
        private System.Windows.Forms.CheckBox IsSaveToVar;
        private System.Windows.Forms.CheckBox IsSaveToLocal;
        private System.Windows.Forms.Label SrcNodeLabel;
        private System.Windows.Forms.Label UpdateMsgLabel;
        private System.Windows.Forms.Label EdgeWeightLabel;
        private System.Windows.Forms.Label DestNodeLabel;
        private System.Windows.Forms.TextBox EdgeWeightTextBox;
        private System.Windows.Forms.TextBox DestNodeTextBox;
        private System.Windows.Forms.TextBox SrcNodeTextBox;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogue;
        private System.Windows.Forms.Label MSTSizeLabel;
        private System.Windows.Forms.Label NoOfEdgesLabel;
        private System.Windows.Forms.Button UpdateAdjListButton;
        private System.Windows.Forms.OpenFileDialog LoadFileDialogue;
        private System.Windows.Forms.CheckBox CheckBoxEditEdges;
        private System.Windows.Forms.CheckBox CheckBoxEditNodes;
        private System.Windows.Forms.CheckBox CheckBoxDelete;
        private System.Windows.Forms.CheckBox CheckBoxUpdate;
        private System.Windows.Forms.CheckBox CheckBoxAdd;
        private System.Windows.Forms.ColumnHeader DestNodesColumn;
        private System.Windows.Forms.Button ShowGraphButton;
        private System.Windows.Forms.Button RunAlgorithmButton;
        private System.Windows.Forms.Button ReLoadOriginalButton;
        private System.Windows.Forms.Label ContainsCyclesLabel;
        private System.Windows.Forms.TextBox DijkstrasSRC;
        private System.Windows.Forms.TextBox DijkstrasDEST;
        private System.Windows.Forms.Label DijkstrasSRCLabel;
        private System.Windows.Forms.Label DijkstrasDESTLabel;
    }
}