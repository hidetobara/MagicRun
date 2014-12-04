using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour
{
	protected Vector3 _Root;
	protected EnemyManager _Manager;
	protected UI2DSprite _Sprite;

	public virtual void Birth(EnemyManager m, Vector3 p)
	{
		_Manager = m;
		_Root = p;
		_Sprite = GetComponent<UI2DSprite>();

		transform.localScale = Vector3.one;
	}

	public virtual void Die()
	{
		StartCoroutine(Dying(1.0f));
	}

	protected IEnumerator Dying(float sec)
	{
		collider2D.enabled = false;
		while (sec > 0)
		{
			_Sprite.color = new Color(sec, sec, sec, sec);
			sec -= Time.deltaTime;
			yield return 0;
		}
		DestroyImmediate(this.gameObject);
	}
}
