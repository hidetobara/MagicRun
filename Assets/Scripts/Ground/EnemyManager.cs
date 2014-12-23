using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scenario;
using Chunker;


public class EnemyManager : MonoBehaviour
{
	ShootingPlayer _Player = new ShootingPlayer();

	List<BaseEnemy> _List = new List<BaseEnemy>();
	public List<BaseEnemy> Enemies { get { return _List; } }

	private float _Time = 0;

	public GameObject EnemyPanel;
	public string DocumentName = "game";

	void Start()
	{
		CreateEnemy(new Enemy(new Vector3(100, 200, 0)));

		TextAsset a = Resources.Load(DocumentName) as TextAsset;
		if (a != null)
		{
			_Player.Load(Chunk.Load(a.bytes));
		}
		print(LogContainer.Singleton().GetInfo());
	}

	void Update()
	{
		_Time += Time.deltaTime;
		CreateEnemies(_Player.Pass(_Time));
	}

	public void CreateEnemies(List<Unit> list)
	{
		if (list.Count == 0) return;
		foreach (Unit u in list)
		{
			Enemy e = u as Enemy;
			if (e == null) continue;
			//print(_Time + ":" + e.Breed + "." + e.Label);
			CreateEnemy(e);
		}
	}

	public void CreateEnemy(Enemy e)
	{
		GameObject go = Instantiate(Resources.Load("DevilPrefab")) as GameObject;
		BaseEnemy b = go.GetComponent<BaseEnemy>();
		go.transform.parent = EnemyPanel.transform;
		b.Birth(this, e);
		Register(b);
	}

	public void Register(BaseEnemy e)
	{
		if (e == null) return;
		_List.Add(e);
	}

	public void Unregister(BaseEnemy e)
	{
		_List.Remove(e);
		e.Die();
	}

	public void Clear()
	{
		foreach (var e in _List) { if (e != null) e.DieSoon(); }
		_List.Clear();
	}
}
