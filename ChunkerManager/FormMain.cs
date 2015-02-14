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
using Chunker;
using Scenario;
using Scenario.Shooting;
using Scenario.Story;


namespace ChunkerManager
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
			ResetStory();
		}

		#region Customize Tree View
		private class ChunkNode : TreeNode
		{
			public string Key { get { return this.Text; } }
			public Chunk Target { set; get; }
			public ChunkNode(string name, Chunk o) { this.Text = name; Target = o; }
		}
		private class ResourceNode : TreeNode
		{
			public string Key { get { return this.Text; } }
			public Resource Target { set; get; }
			public ResourceNode(string name, Resource o) { this.Text = name; Target = o; }
		}
		private class UnitNode : TreeNode
		{
			public string Key { get { return this.Text; } }
			public Unit Target { set; get; }
			public UnitNode(string name, Unit o) { this.Text = name; Target = o; }
		}
		#endregion

		ShootingPlayer _Shooting;
		StoryPlayer _Story;
		private bool IsShootingMode { get { return _Shooting != null; } }
		private bool IsStoryMode { get { return _Story != null; } }

		TreeNode _DocumentNode { get { return TreeViewMain.Nodes[0]; } set { TreeViewMain.Nodes[0] = value; } }
		TreeNode _ResourceNode { get { return TreeViewMain.Nodes[1]; } set { TreeViewMain.Nodes[1] = value; } }

		private void ResetShooting(ShootingPlayer player = null)
		{
			_Story = null;

			_Shooting = player == null ? new ShootingPlayer() : player;
			TreeViewMain.Nodes.Clear();
			TreeViewMain.Nodes.Add(new UnitNode("Document", _Shooting.DocumentBox));
			TreeViewMain.Nodes.Add(new ChunkNode("Resources", _Shooting.ResourceBox));
		}
		private void ResetStory(StoryPlayer player = null)
		{
			_Shooting = null;

			_Story = player == null ? new StoryPlayer() : player;
			TreeViewMain.Nodes.Clear();
			TreeViewMain.Nodes.Add(new UnitNode("Document", _Story.DocumentBox));
			TreeViewMain.Nodes.Add(new ChunkNode("Resources", _Story.ResourceBox));			
		}

		private void ToolStripMenuItemSave_Click(object sender, EventArgs e)
		{
			if (SaveFileDialogMain.ShowDialog() != DialogResult.OK) return;
			if (_Shooting != null) _Shooting.Save(SaveFileDialogMain.FileName);
			if (_Story != null) _Story.Save(SaveFileDialogMain.FileName);
		}

		private void ToolStripMenuItemLoad_Click(object sender, EventArgs e)
		{
			if (OpenFileDialogMain.ShowDialog() != DialogResult.OK) return;

			ShootingPlayer shooting = new ShootingPlayer();
			if (shooting.Load(OpenFileDialogMain.FileName))
			{
				ResetShooting(shooting);
				foreach (var pair in _Shooting.ResourceBox.Table)
					_ResourceNode.Nodes.Add(new ResourceNode(pair.Key, pair.Value));
				(_DocumentNode as UnitNode).Target = _Shooting.DocumentBox;
				BuildTreeUnits(_DocumentNode as UnitNode, _Shooting.DocumentBox);
				return;
			}
			StoryPlayer story = new StoryPlayer();
			if(story.Load(OpenFileDialogMain.FileName))
			{
				ResetStory(story);
				foreach (var pair in _Story.ResourceBox.Table)
					_ResourceNode.Nodes.Add(new ResourceNode(pair.Key, pair.Value));
				(_DocumentNode as UnitNode).Target = _Story.DocumentBox;
				BuildTreeUnits(_DocumentNode as UnitNode, _Story.DocumentBox);
				return;
			}
		}

		private void TreeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
		{
			ResourceNode r = TreeViewMain.SelectedNode as ResourceNode;
			if (r != null)
			{
				PropertyGridMain.SelectedObject = r.Target;
				MemoryStream ms = null;
				try
				{
					ms = new MemoryStream(r.Target.Body as byte[]);
					PictureBoxMain.Image = new Bitmap(ms);
				}
				catch
				{
					PictureBoxMain.Image = null;
				}
				finally
				{
					if (ms != null) ms.Close();
				}
			}
			else
			{
				PictureBoxMain.Image = null;
			}

			UnitNode u = TreeViewMain.SelectedNode as UnitNode;
			if(u != null)
			{
				PropertyGridMain.SelectedObject = u.Target;
			}
		}

		private void ToolStripMenuItemDeleteNode_Click(object sender, EventArgs e)
		{
			ResourceNode r = TreeViewMain.SelectedNode as ResourceNode;
			if (r != null)
			{
				_Shooting.ResourceBox.Remove(r.Key);
				TreeViewMain.Nodes.Remove(r);
			}
		}

		private void ToolStripMenuItemReset_Click(object sender, EventArgs e)
		{
			if (sender == ToolStripMenuItemResetShooting) ResetShooting();
			if (sender == ToolStripMenuItemResetStory) ResetStory();
		}

		private void ToolStripMenuItemNodeAdd_Click(object sender, EventArgs e)
		{
			if (OpenFileDialogNode.ShowDialog() != DialogResult.OK) return;

			Resource r = null;
			if (_Shooting != null) r = _Shooting.ResourceBox.AddFile(OpenFileDialogNode.FileName);
			if (_Story != null) r = _Story.ResourceBox.AddFile(OpenFileDialogNode.FileName);
			if (r == null) return;
			_ResourceNode.Nodes.Add(new ResourceNode(r.Name, r));
		}

		private void ToolStripMenuItemAddUnit_Click(object sender, EventArgs e)
		{
			UnitNode n = TreeViewMain.SelectedNode as UnitNode;
			if (n == null) return;

			if (n.Target is Shooting && sender == ToolStripMenuItemAddStage) { AddTreeUnit(n, new Stage()); }
			if (n.Target is Stage && sender == ToolStripMenuItemAddTimeline) { AddTreeUnit(n, new Timeline()); }
			if (n.Target is Timeline && sender == ToolStripMenuItemAddEnemy) { AddTreeUnit(n, new Enemy()); }
			if (n.Target is Enemy && sender == ToolStripMenuItemAddMove) { AddTreeUnit(n, new ActMove()); }
			if (n.Target is Enemy && sender == ToolStripMenuItemAddFire) { AddTreeUnit(n, new ActFire()); }

			if (n.Target is Story && sender == ToolStripMenuItemStoryAddBlock) { AddTreeUnit(n, new Block()); }
			if (n.Target is Block && sender == ToolStripMenuItemStoryAddCut) { AddTreeUnit(n, new Cut()); }
			if (n.Target is Cut)
			{
				if (sender == ToolStripMenuItemStoryAddImage) { AddTreeUnit(n, new Scenario.Story.Image()); }
				if (sender == ToolStripMenuItemStoryAddText) { AddTreeUnit(n, new Scenario.Story.Text()); }
			}
			if(n.Target is Scenario.Story.Image || n.Target is Scenario.Story.Text)
			{
				if (sender == ToolStripMenuItemStoryAddFix) { AddTreeUnit(n, new Fix()); }
				if (sender == ToolStripMenuItemStoryAddMove) { AddTreeUnit(n, new Move()); }
			}
		}

		private void BuildTreeUnits(UnitNode n, Unit u)
		{
			foreach (Unit uu in u.Units)
			{
				UnitNode nn = new UnitNode(uu.ToString(), uu);
				n.Nodes.Add(nn);
				BuildTreeUnits(nn, uu);
			}
		}

		private void AddTreeUnit(UnitNode target, Unit unit)
		{
			UnitNode n = new UnitNode(unit.ToString(), unit);
			target.Nodes.Add(n);
			target.Target.Add(unit);
		}

		private void removeNodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UnitNode n = TreeViewMain.SelectedNode as UnitNode;
			if (n == null) return;
			n.Target.RemoveSelf();
			n.Remove();
		}
	}
}
