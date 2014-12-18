using UnityEngine;
using System.Collections;

public class DevilHandler : BaseEnemy
{
	void Start()
	{
		StartCoroutine(Firing(3, 2));
	}

	protected IEnumerator Firing(int count, float interval)
	{
		MyHandler me = MyHandler.Singleton();
		while(count > 0)
		{
			yield return new WaitForSeconds(interval);

			GameObject go = Define.InstantiateBall();
			go.layer = Define.FRIEND_FIRE_LAYER;
			me.AdjustGameObjectForFriend(go, Position);
			go.rigidbody2D.velocity = new Vector2(0, -1);
			count--;
		}
	}
}