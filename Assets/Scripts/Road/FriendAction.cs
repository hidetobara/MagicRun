using UnityEngine;
using System.Collections;

public class FriendAction : MonoBehaviour
{
	void Start()
	{

	}

	void Update()
	{
		this.rigidbody2D.AddForce(new Vector2(0.2f, 0));
	}
}
