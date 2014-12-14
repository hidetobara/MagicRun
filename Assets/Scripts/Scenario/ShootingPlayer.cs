using System;
using System.Collections.Generic;
using System.Text;
using Chunker;


namespace Scenario
{
	public class ShootingPlayer
	{
		const string INDEX_DOCUMENT = "index.json";

		LogContainer _Log = LogContainer.Singleton();

		public ShootingGame DocumentBox;
		public Chunk ResourceBox;
		private List<Timeline> _Timelines = new List<Timeline>();
		public int CurrentStage { private set; get; }
		public float CurrentTime { private set; get; }

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
				DocumentBox = ShootingGame.Instance.Parse(r.Body) as ShootingGame;
				ChangeStage(0);
			}
			catch(Exception ex)
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
			catch(Exception ex)
			{
				_Log.AddError(ex.Message);
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
			SortTimelines();
			return true;
		}

		private void SortTimelines() { _Timelines.Sort((Timeline a, Timeline b) => { return (int)((a.Time - b.Time) * 1000.0f); }); }

		private List<Unit> AssignCurrent(Timeline t)
		{
			List<Unit> list = new List<Unit>();
			if(t != null)
			{
				foreach (var e in t.Units) list.Add(e);
				CurrentTime = t.Time;
			}
			return list;
		}

		public List<Unit> Pass(float current)
		{
			List<Unit> list = new List<Unit>();
			if (CurrentTime >= current) return list;

			foreach(Timeline t in _Timelines)
			{
				if (t.Time < CurrentTime) continue;
				if (t.Time >= current) break;

				foreach (var e in t.Units) list.Add(e);
			}
			CurrentTime = current;
			return list;
		}

		public List<Unit> Jump(float time)
		{
			Timeline target = null;
			foreach(Timeline t in _Timelines)
			{
				if (t.Time > time) break;
				target = t;
			}
			return AssignCurrent(target);
		}

		public List<Unit> Next()
		{
			Timeline target = null;
			foreach(Timeline t in _Timelines)
			{
				if (t.Time <= CurrentTime) continue;
				target = t;
				break;
			}
			return AssignCurrent(target);
		}

		public void Remove(float start, float end)
		{
			List<Timeline> remains = new List<Timeline>();
			foreach(Timeline t in _Timelines)
			{
				if (start <= t.Time && t.Time <= end) continue;
				remains.Add(t);
			}
			_Timelines = remains;
		}
		public void Remove(float time) { Remove(time, time); }

		public void Add(float time, List<Unit> list)
		{
			Remove(time);

			Timeline timeline = new Timeline() { Time = time };
			foreach (Unit u in list) timeline.Add(u);
			_Timelines.Add(timeline);
			SortTimelines();
		}

		public void UpdateStage()
		{
			Stage s = DocumentBox.GetStage(CurrentStage);
			s.Units.Clear();
			foreach (Timeline t in _Timelines) s.Add(t);
		}
	}
}
