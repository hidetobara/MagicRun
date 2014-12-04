using UnityEngine;
using System.Collections;

public class DevilHandler : BaseEnemy
{
	// Update is called once per frame
	void Update()
	{
		float theta = Time.timeSinceLevelLoad % Mathf.PI;
		transform.localPosition = _Root + new Vector3(100.0f * Mathf.Sin(theta), 0, 0);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		_Manager.Unregister(this);
	}
}