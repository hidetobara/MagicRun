using System;
using System.Collections.Generic;
using System.Text;

namespace Scenario
{
	public class LogContainer
	{
		private static LogContainer _Instance = null;
		public static LogContainer Singleton()
		{
			if (_Instance == null) _Instance = new LogContainer();
			return _Instance;
		}
		private LogContainer() { }

		private List<string> _Info = new List<string>();
		private List<string> _Error = new List<string>();

		public void Clear() { _Info.Clear(); _Error.Clear(); }
		public void AddInfo(string s) { _Info.Add(s); }
		public void AddError(string s) { _Info.Add(s); _Error.Add(s); }

		public string GetInfo() { return string.Join(Environment.NewLine, _Info.ToArray()); }
		public string GetError() { return string.Join(Environment.NewLine, _Error.ToArray()); }

		public void Print(string s) { UnityEngine.MonoBehaviour.print(s); }
	}
}
