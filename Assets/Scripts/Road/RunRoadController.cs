using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


class RunRoadController : MonoBehaviour
{
	public Camera MainCamera;

	List<GameObject> Friends = new List<GameObject>();

	void Start()
	{
		FriendAction[] friends = FindObjectsOfType<FriendAction>();
		foreach (FriendAction fa in friends)
		{
			foreach (FriendAction fb in friends)
			{
				if (fa == fb) continue;
				Debug.Log("Collision ignore: " + fa.name + "-" + fb.name);
				Physics2D.IgnoreCollision(fa.collider2D, fb.collider2D);
			}
		}

		foreach (FriendAction f in friends)
		{
			Friends.Add(f.gameObject);
		}
	}

	void Update()
	{
		Vector3 sum = new Vector3();
		foreach (GameObject go in Friends) sum += go.transform.localPosition;
		Vector3 pos = MainCamera.transform.localPosition;
		pos.x = sum.x / Friends.Count;
		MainCamera.transform.localPosition = pos;
	}
}

