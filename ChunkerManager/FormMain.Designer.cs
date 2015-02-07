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
			this.ToolStripMenuItemResetShooting = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemResetStory = new System.Windows.Forms.ToolStripMenuItem();
			this.nodeNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemNodeAddFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemAddStage = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemAddTimeline = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemAddEnemy = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemAddMove = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemAddFire = new System.Windows.Forms.ToolStripMenuItem();
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
			this.storyTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemStoryAddFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemStoryAddBlock = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemStoryAddCut = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemStoryAddImage = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemStoryAddText = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemStoryAddFix = new System.Windows.Forms.ToolStripMenuItem();
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
            this.nodeNToolStripMenuItem,
            this.storyTToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(592, 26);
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
			this.fileFToolStripMenuItem.Size = new System.Drawing.Size(57, 22);
			this.fileFToolStripMenuItem.Text = "File(&F)";
			// 
			// ToolStripMenuItemSave
			// 
			this.ToolStripMenuItemSave.Name = "ToolStripMenuItemSave";
			this.ToolStripMenuItemSave.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemSave.Text = "Save(&S)";
			this.ToolStripMenuItemSave.Click += new System.EventHandler(this.ToolStripMenuItemSave_Click);
			// 
			// ToolStripMenuItemLoad
			// 
			this.ToolStripMenuItemLoad.Name = "ToolStripMenuItemLoad";
			this.ToolStripMenuItemLoad.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemLoad.Text = "Load(&L)";
			this.ToolStripMenuItemLoad.Click += new System.EventHandler(this.ToolStripMenuItemLoad_Click);
			// 
			// ToolStripMenuItemReset
			// 
			this.ToolStripMenuItemReset.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemResetShooting,
            this.ToolStripMenuItemResetStory});
			this.ToolStripMenuItemReset.Name = "ToolStripMenuItemReset";
			this.ToolStripMenuItemReset.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemReset.Text = "Reset(&R)";
			this.ToolStripMenuItemReset.Click += new System.EventHandler(this.ToolStripMenuItemReset_Click);
			// 
			// ToolStripMenuItemResetShooting
			// 
			this.ToolStripMenuItemResetShooting.Name = "ToolStripMenuItemResetShooting";
			this.ToolStripMenuItemResetShooting.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemResetShooting.Text = "Shooting";
			this.ToolStripMenuItemResetShooting.Click += new System.EventHandler(this.ToolStripMenuItemReset_Click);
			// 
			// ToolStripMenuItemResetStory
			// 
			this.ToolStripMenuItemResetStory.Name = "ToolStripMenuItemResetStory";
			this.ToolStripMenuItemResetStory.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemResetStory.Text = "Story";
			this.ToolStripMenuItemResetStory.Click += new System.EventHandler(this.ToolStripMenuItemReset_Click);
			// 
			// nodeNToolStripMenuItem
			// 
			this.nodeNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNodeAddFile,
            this.toolStripSeparator1,
            this.ToolStripMenuItemAddStage,
            this.ToolStripMenuItemAddTimeline,
            this.ToolStripMenuItemAddEnemy,
            this.toolStripSeparator2,
            this.ToolStripMenuItemAddMove,
            this.ToolStripMenuItemAddFire});
			this.nodeNToolStripMenuItem.Name = "nodeNToolStripMenuItem";
			this.nodeNToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
			this.nodeNToolStripMenuItem.Text = "Shooting(&H)";
			// 
			// ToolStripMenuItemNodeAddFile
			// 
			this.ToolStripMenuItemNodeAddFile.Name = "ToolStripMenuItemNodeAddFile";
			this.ToolStripMenuItemNodeAddFile.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemNodeAddFile.Text = "Add File(&A)";
			this.ToolStripMenuItemNodeAddFile.Click += new System.EventHandler(this.ToolStripMenuItemNodeAdd_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// ToolStripMenuItemAddStage
			// 
			this.ToolStripMenuItemAddStage.Name = "ToolStripMenuItemAddStage";
			this.ToolStripMenuItemAddStage.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemAddStage.Text = "Add Stage";
			this.ToolStripMenuItemAddStage.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// ToolStripMenuItemAddTimeline
			// 
			this.ToolStripMenuItemAddTimeline.Name = "ToolStripMenuItemAddTimeline";
			this.ToolStripMenuItemAddTimeline.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemAddTimeline.Text = "Add Timeline";
			this.ToolStripMenuItemAddTimeline.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// ToolStripMenuItemAddEnemy
			// 
			this.ToolStripMenuItemAddEnemy.Name = "ToolStripMenuItemAddEnemy";
			this.ToolStripMenuItemAddEnemy.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemAddEnemy.Text = "Add Enemy";
			this.ToolStripMenuItemAddEnemy.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// ToolStripMenuItemAddMove
			// 
			this.ToolStripMenuItemAddMove.Name = "ToolStripMenuItemAddMove";
			this.ToolStripMenuItemAddMove.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemAddMove.Text = "Add Move";
			this.ToolStripMenuItemAddMove.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// ToolStripMenuItemAddFire
			// 
			this.ToolStripMenuItemAddFire.Name = "ToolStripMenuItemAddFire";
			this.ToolStripMenuItemAddFire.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemAddFire.Text = "Add Fire";
			this.ToolStripMenuItemAddFire.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 26);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.TreeViewMain);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(592, 347);
			this.splitContainer1.SplitterDistance = 197;
			this.splitContainer1.TabIndex = 1;
			// 
			// TreeViewMain
			// 
			this.TreeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TreeViewMain.Location = new System.Drawing.Point(0, 0);
			this.TreeViewMain.Name = "TreeViewMain";
			this.TreeViewMain.Size = new System.Drawing.Size(197, 347);
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
			this.splitContainer2.Size = new System.Drawing.Size(391, 347);
			this.splitContainer2.SplitterDistance = 246;
			this.splitContainer2.TabIndex = 1;
			// 
			// PropertyGridMain
			// 
			this.PropertyGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PropertyGridMain.Location = new System.Drawing.Point(0, 0);
			this.PropertyGridMain.Name = "PropertyGridMain";
			this.PropertyGridMain.Size = new System.Drawing.Size(391, 246);
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
			this.ContextMenuStripMain.Size = new System.Drawing.Size(134, 26);
			// 
			// ToolStripMenuItemDeleteNode
			// 
			this.ToolStripMenuItemDeleteNode.Name = "ToolStripMenuItemDeleteNode";
			this.ToolStripMenuItemDeleteNode.Size = new System.Drawing.Size(133, 22);
			this.ToolStripMenuItemDeleteNode.Text = "Delete(&D)";
			this.ToolStripMenuItemDeleteNode.Click += new System.EventHandler(this.ToolStripMenuItemDeleteNode_Click);
			// 
			// OpenFileDialogNode
			// 
			this.OpenFileDialogNode.Filter = "*.*|*.*";
			this.OpenFileDialogNode.Title = "ファイルの選択";
			// 
			// storyTToolStripMenuItem
			// 
			this.storyTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemStoryAddFile,
            this.toolStripSeparator3,
            this.ToolStripMenuItemStoryAddBlock,
            this.ToolStripMenuItemStoryAddCut,
            this.toolStripSeparator4,
            this.ToolStripMenuItemStoryAddImage,
            this.ToolStripMenuItemStoryAddText,
            this.toolStripSeparator5,
            this.ToolStripMenuItemStoryAddFix});
			this.storyTToolStripMenuItem.Name = "storyTToolStripMenuItem";
			this.storyTToolStripMenuItem.Size = new System.Drawing.Size(70, 22);
			this.storyTToolStripMenuItem.Text = "Story(&T)";
			// 
			// ToolStripMenuItemStoryAddFile
			// 
			this.ToolStripMenuItemStoryAddFile.Name = "ToolStripMenuItemStoryAddFile";
			this.ToolStripMenuItemStoryAddFile.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemStoryAddFile.Text = "Add File";
			this.ToolStripMenuItemStoryAddFile.Click += new System.EventHandler(this.ToolStripMenuItemNodeAdd_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
			// 
			// ToolStripMenuItemStoryAddBlock
			// 
			this.ToolStripMenuItemStoryAddBlock.Name = "ToolStripMenuItemStoryAddBlock";
			this.ToolStripMenuItemStoryAddBlock.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemStoryAddBlock.Text = "Add Block";
			this.ToolStripMenuItemStoryAddBlock.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// ToolStripMenuItemStoryAddCut
			// 
			this.ToolStripMenuItemStoryAddCut.Name = "ToolStripMenuItemStoryAddCut";
			this.ToolStripMenuItemStoryAddCut.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemStoryAddCut.Text = "Add Cut";
			this.ToolStripMenuItemStoryAddCut.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
			// 
			// ToolStripMenuItemStoryAddImage
			// 
			this.ToolStripMenuItemStoryAddImage.Name = "ToolStripMenuItemStoryAddImage";
			this.ToolStripMenuItemStoryAddImage.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemStoryAddImage.Text = "Add Image";
			this.ToolStripMenuItemStoryAddImage.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// ToolStripMenuItemStoryAddText
			// 
			this.ToolStripMenuItemStoryAddText.Name = "ToolStripMenuItemStoryAddText";
			this.ToolStripMenuItemStoryAddText.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemStoryAddText.Text = "Add Text";
			this.ToolStripMenuItemStoryAddText.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
			// 
			// ToolStripMenuItemStoryAddFix
			// 
			this.ToolStripMenuItemStoryAddFix.Name = "ToolStripMenuItemStoryAddFix";
			this.ToolStripMenuItemStoryAddFix.Size = new System.Drawing.Size(152, 22);
			this.ToolStripMenuItemStoryAddFix.Text = "Add Fix";
			this.ToolStripMenuItemStoryAddFix.Click += new System.EventHandler(this.ToolStripMenuItemAddUnit_Click);
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
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddMove;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddFire;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemResetShooting;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemResetStory;
		private System.Windows.Forms.ToolStripMenuItem storyTToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStoryAddFile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStoryAddBlock;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStoryAddCut;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStoryAddImage;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStoryAddText;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStoryAddFix;
	}
}

