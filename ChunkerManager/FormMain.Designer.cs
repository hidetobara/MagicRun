namespace ChunkerManager
{
	partial class FormMain
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemReset = new System.Windows.Forms.ToolStripMenuItem();
			this.nodeNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemNodeAddFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemAddStage = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemAddTimeline = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemAddEnemy = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.TreeViewMain = new System.Windows.Forms.TreeView();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.PropertyGridMain = new System.Windows.Forms.PropertyGrid();
			this.PictureBoxMain = new System.Windows.Forms.PictureBox();
			this.OpenFileDialogMain = new System.Windows.Forms.OpenFileDialog();
			this.SaveFileDialogMain = new System.Windows.Forms.SaveFileDialog();
			this.ContextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolStripMenuItemDeleteNode = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenFileDialogNode = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).BeginInit();
			this.ContextMenuStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.nodeNToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(592, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileFToolStripMenuItem
			// 
			this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSave,
            this.ToolStripMenuItemLoad,
            this.ToolStripMenuItemReset});
			this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
			this.fileFToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.fileFToolStripMenuItem.Text = "File(&F)";
			// 
			// ToolStripMenuItemSave
			// 
			this.ToolStripMenuItemSave.Name = "ToolStripMenuItemSave";
			this.ToolStripMenuItemSave.Size = new System.Drawing.Size(116, 22);
			this.ToolStripMenuItemSave.Text = "Save(&S)";
			this.ToolStripMenuItemSave.Click += new System.EventHandler(this.ToolStripMenuItemSave_Click);
			// 
			// ToolStripMenuItemLoad
			// 
			this.ToolStripMenuItemLoad.Name = "ToolStripMenuItemLoad";
			this.ToolStripMenuItemLoad.Size = new System.Drawing.Size(116, 22);
			this.ToolStripMenuItemLoad.Text = "Load(&L)";
			this.ToolStripMenuItemLoad.Click += new System.EventHandler(this.ToolStripMenuItemLoad_Click);
			// 
			// ToolStripMenuItemReset
			// 
			this.ToolStripMenuItemReset.Name = "ToolStripMenuItemReset";
			this.ToolStripMenuItemReset.Size = new System.Drawing.Size(116, 22);
			this.ToolStripMenuItemReset.Text = "Reset(&R)";
			this.ToolStripMenuItemReset.Click += new System.EventHandler(this.ToolStripMenuItemReset_Click);
			// 
			// nodeNToolStripMenuItem
			// 
			this.nodeNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNodeAddFile,
            this.toolStripSeparator1,
            this.ToolStripMenuItemAddStage,
            this.ToolStripMenuItemAddTimeline,
            this.ToolStripMenuItemAddEnemy});
			this.nodeNToolStripMenuItem.Name = "nodeNToolStripMenuItem";
			this.nodeNToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.nodeNToolStripMenuItem.Text = "Node(&N)";
			// 
			// ToolStripMenuItemNodeAddFile
			// 
			this.ToolStripMenuItemNodeAddFile.Name = "ToolStripMenuItemNodeAddFile";
			this.ToolStripMenuItemNodeAddFile.Size = new System.Drawing.Size(137, 22);
			this.ToolStripMenuItemNodeAddFile.Text = "Add File(&A)";
			this.ToolStripMenuItemNodeAddFile.Click += new System.EventHandler(this.ToolStripMenuItemNodeAdd_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
			// 
			// ToolStripMenuItemAddStage
			// 
			this.ToolStripMenuItemAddStage.Name = "ToolStripMenuItemAddStage";
			this.ToolStripMenuItemAddStage.Size = new System.Drawing.Size(137, 22);
			this.ToolStripMenuItemAddStage.Text = "Add Stage";
			this.ToolStripMenuItemAddStage.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// ToolStripMenuItemAddTimeline
			// 
			this.ToolStripMenuItemAddTimeline.Name = "ToolStripMenuItemAddTimeline";
			this.ToolStripMenuItemAddTimeline.Size = new System.Drawing.Size(137, 22);
			this.ToolStripMenuItemAddTimeline.Text = "Add Timeline";
			this.ToolStripMenuItemAddTimeline.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// ToolStripMenuItemAddEnemy
			// 
			this.ToolStripMenuItemAddEnemy.Name = "ToolStripMenuItemAddEnemy";
			this.ToolStripMenuItemAddEnemy.Size = new System.Drawing.Size(137, 22);
			this.ToolStripMenuItemAddEnemy.Text = "Add Enemy";
			this.ToolStripMenuItemAddEnemy.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.TreeViewMain);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(592, 349);
			this.splitContainer1.SplitterDistance = 197;
			this.splitContainer1.TabIndex = 1;
			// 
			// TreeViewMain
			// 
			this.TreeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TreeViewMain.Location = new System.Drawing.Point(0, 0);
			this.TreeViewMain.Name = "TreeViewMain";
			this.TreeViewMain.Size = new System.Drawing.Size(197, 349);
			this.TreeViewMain.TabIndex = 0;
			this.TreeViewMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewMain_AfterSelect);
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.PropertyGridMain);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.PictureBoxMain);
			this.splitContainer2.Size = new System.Drawing.Size(391, 349);
			this.splitContainer2.SplitterDistance = 248;
			this.splitContainer2.TabIndex = 1;
			// 
			// PropertyGridMain
			// 
			this.PropertyGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PropertyGridMain.Location = new System.Drawing.Point(0, 0);
			this.PropertyGridMain.Name = "PropertyGridMain";
			this.PropertyGridMain.Size = new System.Drawing.Size(391, 248);
			this.PropertyGridMain.TabIndex = 0;
			// 
			// PictureBoxMain
			// 
			this.PictureBoxMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.PictureBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PictureBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PictureBoxMain.Location = new System.Drawing.Point(0, 0);
			this.PictureBoxMain.Name = "PictureBoxMain";
			this.PictureBoxMain.Size = new System.Drawing.Size(391, 97);
			this.PictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBoxMain.TabIndex = 0;
			this.PictureBoxMain.TabStop = false;
			// 
			// OpenFileDialogMain
			// 
			this.OpenFileDialogMain.Filter = "*.bytes|*.bytes|*.*|*.*";
			this.OpenFileDialogMain.Title = "読み込み";
			// 
			// SaveFileDialogMain
			// 
			this.SaveFileDialogMain.Filter = "*.bytes|*.bytes|*.*|*.*";
			this.SaveFileDialogMain.Title = "書き込み";
			// 
			// ContextMenuStripMain
			// 
			this.ContextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDeleteNode});
			this.ContextMenuStripMain.Name = "ContextMenuStripMain";
			this.ContextMenuStripMain.Size = new System.Drawing.Size(120, 26);
			// 
			// ToolStripMenuItemDeleteNode
			// 
			this.ToolStripMenuItemDeleteNode.Name = "ToolStripMenuItemDeleteNode";
			this.ToolStripMenuItemDeleteNode.Size = new System.Drawing.Size(119, 22);
			this.ToolStripMenuItemDeleteNode.Text = "Delete(&D)";
			this.ToolStripMenuItemDeleteNode.Click += new System.EventHandler(this.ToolStripMenuItemDeleteNode_Click);
			// 
			// OpenFileDialogNode
			// 
			this.OpenFileDialogNode.Filter = "*.*|*.*";
			this.OpenFileDialogNode.Title = "ファイルの選択";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 373);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormMain";
			this.Text = "Chunker";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).EndInit();
			this.ContextMenuStripMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSave;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLoad;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView TreeViewMain;
		private System.Windows.Forms.PropertyGrid PropertyGridMain;
		private System.Windows.Forms.OpenFileDialog OpenFileDialogMain;
		private System.Windows.Forms.SaveFileDialog SaveFileDialogMain;
		private System.Windows.Forms.ContextMenuStrip ContextMenuStripMain;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteNode;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReset;
		private System.Windows.Forms.ToolStripMenuItem nodeNToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemNodeAddFile;
		private System.Windows.Forms.OpenFileDialog OpenFileDialogNode;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.PictureBox PictureBoxMain;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddStage;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddTimeline;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddEnemy;
	}
}

