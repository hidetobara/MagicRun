using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
	List<BaseEnemy> _List = new List<BaseEnemy>();

	public GameObject CharacterLayer;

	void Start()
	{
		CreateNormalEnemy();
	}

	void Update()
	{
		if (_List.Count == 0) CreateNormalEnemy();
	}

	private void CreateNormalEnemy()
	{
		GameObject go = Instantiate(Resources.Load("DevilPrefab")) as GameObject;
		Register(go.GetComponent<BaseEnemy>());
	}

	public void Register(BaseEnemy e)
	{
		if (e == null) return;

		e.transform.parent = CharacterLayer.transform;
		e.Birth(this, new Vector3(Random.Range(-200, 200), 100, 0));
		_List.Add(e);
	}

	public void Unregister(BaseEnemy e)
	{
		_List.Remove(e);
		e.Die();
	}

}
