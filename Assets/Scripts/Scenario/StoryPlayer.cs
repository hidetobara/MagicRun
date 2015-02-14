using System;
using System.Collections.Generic;
using System.Text;
using Chunker;
using System.Diagnostics;


namespace Scenario.Story
{
	public class StoryPlayer
	{
		const string INDEX_DOCUMENT = "index.json";
		public enum PlayStatus { NONE, PLAYING, FINISHED, ERROR }

		LogContainer _Log = LogContainer.Singleton();

		public Story DocumentBox = new Story();
		public Chunk ResourceBox = new Chunk();

		private Stopwatch _Stopwatch = new Stopwatch();
		private List<Cut> _FlowCut = new List<Cut>();
		private int _FlowIndex = 0;
		private Cut _CurrentCut;
		public PlayStatus CurrentStatus { get; private set; }
		public List<Image> CurrentImages { get; private set; }
		public Text CurrentText { get; private set; }

		public StoryPlayer()
		{
			CurrentImages = new List<Image>();
		}

		public bool Load(string path)
		{
			return Load(Chunk.Load(path));
		}

		public bool Load(Chunk c)
		{
			if (c == null) return false;
			try
			{
				ResourceBox = c;
				Chunk d = ResourceBox.Cutout(INDEX_DOCUMENT);
				Resource r = d.Get(INDEX_DOCUMENT);
				DocumentBox = Story.Instance.Parse(r.Body) as Story;
			}
			catch (Exception ex)
			{
				_Log.AddError(ex.Message);
				return false;
			}
			return true;
		}

		public bool Save(string path)
		{
			try
			{
				Chunk c = new Chunk();
				c.AddObject(INDEX_DOCUMENT, DocumentBox.ToHash());
				Chunk cc = Chunk.Merge(c, ResourceBox);
				cc.Save(path);
			}
			catch (Exception ex)
			{
				_Log.AddError(ex.Message);
				return false;
			}
			return true;
		}

		public void BuildFlow()
		{
			_FlowCut.Clear();
			_FlowIndex = 0;

			foreach(Unit u1 in DocumentBox.Units)
			{
				Print("*");
				Block b = u1 as Block;
				if (b == null) return;
				foreach(Unit u2 in b.Units)
				{
					Cut c = u2 as Cut;
					if (c == null) return;
					_FlowCut.Add(c);
				}
			}

			CurrentStatus = PlayStatus.PLAYING;
			Next();
		}

		public void Next()
		{
			try
			{
				if (_FlowIndex >= _FlowCut.Count)
				{
					CurrentStatus = PlayStatus.FINISHED;
					return;
				}

				CurrentImages.Clear();
				CurrentText = null;

				Cut c = _FlowCut[_FlowIndex];
				if (c.Parent != null) AssignCurrentUnits(c.Parent);
				AssignCurrentUnits(c);
				_CurrentCut = c;

				_FlowIndex++;
				_Stopwatch.Reset();
				_Stopwatch.Start();
			}
			catch(Exception ex)
			{
				Print(ex.Message + Environment.NewLine + ex.StackTrace);
			}
		}

		public bool IsCutOver()
		{
			return _CurrentCut != null && _Stopwatch.IsRunning && _CurrentCut.Time < _Stopwatch.ElapsedMilliseconds / 1000.0f;
		}

		private void AssignCurrentUnits(Unit p)
		{
			if(p != null)
			{
				foreach(Unit u in p.Units)
				{
					if(u is Text)
					{
						CurrentText = u as Text;
					}
					else if(u is Image)
					{
						CurrentImages.Add(u as Image);
					}
				}
			}
		}

		private void Print(string s)
		{
			UnityEngine.MonoBehaviour.print(s);
		}
	}
}
