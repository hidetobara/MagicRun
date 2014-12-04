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

		const string INDEX_DOCUMENT = "index.json";

		ShootingGame _Document;
		Chunk _Resources;
		TreeNode _DocumentNode { get { return TreeViewMain.Nodes[0]; } set { TreeViewMain.Nodes[0] = value; } }
		TreeNode _ResourceNode { get { return TreeViewMain.Nodes[1]; } set { TreeViewMain.Nodes[1] = value; } }
		private void Reset()
		{
			_Document = new ShootingGame();
			_Resources = new Chunk();

			TreeViewMain.Nodes.Clear();
			TreeViewMain.Nodes.Add(new UnitNode("Document", _Document));
			TreeViewMain.Nodes.Add(new ChunkNode("Resources", _Resources));
		}

		private void ToolStripMenuItemSave_Click(object sender, EventArgs e)
		{
			if (SaveFileDialogMain.ShowDialog() != DialogResult.OK) return;

			Chunk c = new Chunk();
			c.AddObject(INDEX_DOCUMENT, _Document.ToHash());
			Chunk.Save(SaveFileDialogMain.FileName, Chunk.Merge(c, _Resources));
		}

		private void ToolStripMenuItemLoad_Click(object sender, EventArgs e)
		{
			if (OpenFileDialogMain.ShowDialog() != DialogResult.OK) return;

			Reset();

			Chunk c = Chunk.Load(OpenFileDialogMain.FileName);
			Chunk d = c.Cutout(INDEX_DOCUMENT);
			foreach (var pair in c.Table)
			{
				ResourceNode n = new ResourceNode(pair.Key, pair.Value);
				_ResourceNode.Nodes.Add(n);
			}
			Resource r = d.Get(INDEX_DOCUMENT);
			_Document = ShootingGame.Instance.Parse(r.Body) as ShootingGame;
			(_DocumentNode as UnitNode).Target = _Document;
			BuildTreeUnits(_DocumentNode as UnitNode, _Document);
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
				_Resources.Table.Remove(r.Key);
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

			string key = _Resources.AddFile(OpenFileDialogNode.FileName);
			if (key == null) return;
			Resource value = _Resources.Table[key];
			_ResourceNode.Nodes.Add(new ResourceNode(key, value));
		}

		private void ToolStripMenuItemAddUnit_Click(object sender, EventArgs e)
		{
			UnitNode n = TreeViewMain.SelectedNode as UnitNode;
			if(n != null)
			{
				if (n.Target is ShootingGame && sender == ToolStripMenuItemAddStage) { AddTreeUnit(n, new Stage()); }
				if (n.Target is Stage && sender == ToolStripMenuItemAddTimeline) { AddTreeUnit(n, new Timeline()); }
				if (n.Target is Timeline && sender == ToolStripMenuItemAddEnemy) { AddTreeUnit(n, new Enemy()); }
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
