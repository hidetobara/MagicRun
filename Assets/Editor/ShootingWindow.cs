using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Scenario;
using Chunker;


public class ShootingWindow : EditorWindow
{
	static ShootingWindow _Window;

	[MenuItem("Window/Shooting-Window")]
	static void Open()
	{
		_Window = EditorWindow.GetWindow<ShootingWindow>("Shooting");
		_Window.Show();
	}

	float _Time = 0;
	string _Name = "Resources/game.bytes";
	int _Stage = 0;
	ShootingPlayer _Player;

	void OnGUI()
	{
		_Name = EditorGUILayout.TextField("File name", _Name);
		_Stage = EditorGUILayout.IntField("Stage", _Stage);
		if (GetEnemyManager() == null) return;

		if (_Player == null)
		{
			GuiLoad();
		}
		else
		{
			GuiSeek();
			GuiAddEnemy();
			GuiAddTimeline();
			GuiSave();
			GuiClose();
		}
	}

	private void GuiLoad()
	{
		if (GUILayout.Button("Load"))
		{
			string path = System.IO.Path.Combine(Application.dataPath, _Name);
			_Player = new ShootingPlayer();
			if (!_Player.Load(path)) _Player = null;
			else _Player.ChangeStage(_Stage);
			GetEnemyManager().Clear();
		}
	}

	private void GuiSeek()
	{
		_Time = EditorGUILayout.FloatField("Time", _Time);
		List<Unit> list = null;

		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("Jump"))
		{
			list = _Player.Jump(_Time);
			_Time = _Player.CurrentTime;
		}
		if (GUILayout.Button("Next"))
		{
			list = _Player.Next();
			_Time = _Player.CurrentTime;
		}
		EditorGUILayout.EndHorizontal();

		if (list != null && list.Count > 0)
		{
			GetEnemyManager().Clear();
			GetEnemyManager().CreateEnemies(list);
		}
	}

	Vector3 _Position;
	private void GuiAddEnemy()
	{
		_Position = EditorGUILayout.Vector3Field("Position", _Position);
		if (GUILayout.Button("Add Enemy"))
		{
			GetEnemyManager().CreateEnemy(new Enemy(_Position));
		}
	}

	private void GuiAddTimeline()
	{
		if (GUILayout.Button("Add Timeline"))
		{
			List<BaseEnemy> enemies = GetEnemyManager().Enemies;
			List<Unit> units = new List<Unit>();
			foreach(BaseEnemy b in enemies)
			{
				b.FirstPosition = b.transform.localPosition;
				Debug.Log(b.FirstPosition);
				units.Add(b.Enemey);
			}
			if (units.Count > 0) _Player.Add(_Time, units);
		}		
	}

	private void GuiSave()
	{
		if(GUILayout.Button("Save"))
		{
			string path = System.IO.Path.Combine(Application.dataPath, _Name);
			_Player.UpdateStage();
			_Player.Save(path);
			Debug.Log(LogContainer.Singleton().GetInfo());
		}
	}

	private void GuiClose()
	{
		if(GUILayout.Button("Close"))
		{
			GetEnemyManager().Clear();
			_Player = null;
		}
	}

	EnemyManager _EnemyManager = null;
	private EnemyManager GetEnemyManager()
	{
		if(_EnemyManager == null) _EnemyManager = FindObjectOfType<EnemyManager>();
		return _EnemyManager;
	}
}
