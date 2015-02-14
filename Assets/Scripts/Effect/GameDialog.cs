using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


namespace Scenario
{
	class GameDialog : MonoBehaviour
	{
		static GameDialog _Instance = null;
		public static GameDialog Instance
		{
			get { if (_Instance == null) _Instance = FindObjectOfType<GameDialog>(); return _Instance; }
		}

		public Action OnPressAnywhere;

		void Start()
		{

		}

		void OnPress(bool press)
		{
			if (press)
			{
				if (OnPressAnywhere != null) OnPressAnywhere();
			}
		}
	}
}
