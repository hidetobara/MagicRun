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


namespace ChunkerManager
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
			Reset();
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

		ShootingPlayer _Player;

		TreeNode _DocumentNode { get { return TreeViewMain.Nodes[0]; } set { TreeViewMain.Nodes[0] = value; } }
		TreeNode _ResourceNode { get { return TreeViewMain.Nodes[1]; } set { TreeViewMain.Nodes[1] = value; } }
		private void Reset()
		{
			_Player = new ShootingPlayer();

			TreeViewMain.Nodes.Clear();
			TreeViewMain.Nodes.Add(new UnitNode("Document", _Player.DocumentBox));
			TreeViewMain.Nodes.Add(new ChunkNode("Resources", _Player.ResourceBox));
		}

		private void ToolStripMenuItemSave_Click(object sender, EventArgs e)
		{
			if (SaveFileDialogMain.ShowDialog() != DialogResult.OK) return;
			_Player.Save(SaveFileDialogMain.FileName);
		}

		private void ToolStripMenuItemLoad_Click(object sender, EventArgs e)
		{
			if (OpenFileDialogMain.ShowDialog() != DialogResult.OK) return;

			Reset();
			if (!_Player.Load(OpenFileDialogMain.FileName)) return;

			foreach (var pair in _Player.ResourceBox.Table)
			{
				ResourceNode n = new ResourceNode(pair.Key, pair.Value);
				_ResourceNode.Nodes.Add(n);
			}
			(_DocumentNode as UnitNode).Target = _Player.DocumentBox;
			BuildTreeUnits(_DocumentNode as UnitNode, _Player.DocumentBox);
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
				_Player.ResourceBox.Remove(r.Key);
				TreeViewMain.Nodes.Remove(r);
			}
		}

		private void ToolStripMenuItemReset_Click(object sender, EventArgs e)
		{
			Reset();
		}

		private void ToolStripMenuItemNodeAdd_Click(object sender, EventArgs e)
		{
			if (OpenFileDialogNode.ShowDialog() != DialogResult.OK) return;

			Resource r = _Player.ResourceBox.AddFile(OpenFileDialogNode.FileName);
			if (r == null) return;
			_ResourceNode.Nodes.Add(new ResourceNode(r.Name, r));
		}

		private void ToolStripMenuItemAddUnit_Click(object sender, EventArgs e)
		{
			UnitNode n = TreeViewMain.SelectedNode as UnitNode;
			if(n != null)
			{
				if (n.Target is ShootingGame && sender == ToolStripMenuItemAddStage) { AddTreeUnit(n, new Stage()); }
				if (n.Target is Stage && sender == ToolStripMenuItemAddTimeline) { AddTreeUnit(n, new Timeline()); }
				if (n.Target is Timeline && sender == ToolStripMenuItemAddEnemy) { AddTreeUnit(n, new Enemy()); }
				if (n.Target is Enemy && sender == ToolStripMenuItemAddMove) { AddTreeUnit(n, new ActMove()); }
				if (n.Target is Enemy && sender == ToolStripMenuItemAddFire) { AddTreeUnit(n, new ActFire()); }
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
	}
}
