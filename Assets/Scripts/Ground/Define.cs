using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class Define
{
	public readonly static int FRIEND_LAYER = LayerMask.NameToLayer("Friend");
	public readonly static int ENEMY_LAYER = LayerMask.NameToLayer("Enemy");
	public readonly static int FRIEND_FIRE_LAYER = LayerMask.NameToLayer("FriendFire");
	public readonly static int ENEMY_FIRE_LAYER = LayerMask.NameToLayer("EnemyFire");

	public static GameObject InstantiateBall()
	{
		return MonoBehaviour.Instantiate(Resources.Load("BallPrefab")) as GameObject;
	}
	public static GameObject InstantiateFire()
	{
		return MonoBehaviour.Instantiate(Resources.Load("FirePrefab")) as GameObject;
	}
}
