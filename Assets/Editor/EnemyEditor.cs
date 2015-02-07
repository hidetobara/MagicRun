using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(EnemyDevil))]
public class EnemyEditor : Editor
{
	Vector3 _Position;

	public override void OnInspectorGUI()
	{
		BaseEnemy e = target as EnemyDevil;
		if (e == null) return;

		_Position = EditorGUILayout.Vector3Field("Position", _Position);
		EditorGUILayout.Space();
		EditorUtility.SetDirty(target);
	}
}
