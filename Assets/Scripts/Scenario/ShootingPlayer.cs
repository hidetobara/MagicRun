using System;
using System.Collections.Generic;
using System.Text;
using Chunker;


namespace Scenario
{
	public class ShootingPlayer
	{
		const string INDEX_DOCUMENT = "index.json";

		public ShootingGame DocumentBox;
		public Chunk ResourceBox;
		private List<Timeline> _Timelines = new List<Timeline>();
		public int CurrentStage { private set; get; }
		public float CurrentTime { private set; get; }

		public bool Load(string path)
		{
			try
			{
				ResourceBox = Chunk.Load(path);
				Chunk d = ResourceBox.Cutout(INDEX_DOCUMENT);
				Resource r = d.Get(INDEX_DOCUMENT);
				DocumentBox = ShootingGame.Instance.Parse(r.Body) as ShootingGame;
				ChangeStage(0);
			}
			catch(Exception ex)
			{
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
				Chunk.Save(path, Chunk.Merge(c, ResourceBox));
			}
			catch(Exception ex)
			{
				return false;
			}
			return true;
		}

		public bool ChangeStage(int stage)
		{
			CurrentStage = stage;
			CurrentTime = 0;

			Stage s = DocumentBox.GetStage(CurrentStage);
			if (s == null) return false;
			
			foreach(var u in s.Units)
			{
				Timeline t = u as Timeline;
				if (t != null) _Timelines.Add(t);
			}
			_Timelines.Sort((Timeline a, Timeline b) => { return (int)((a.Second - b.Second) * 100.0f); });
			return true;
		}

		public List<Unit> Pass(float current)
		{
			List<Unit> list = new List<Unit>();
			if (CurrentTime >= current) return list;

			foreach(var t in _Timelines)
			{
				if (t.Second < CurrentTime) continue;
				else if (t.Second < current) list.Add(t);
				else break;
			}
			CurrentTime = current;
			return list;
		}
	}
}
