using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Chunker;
using Scenario;
using Scenario.Story;
using UnityEngine;


class GroundHandler : MonoBehaviour
{
	StoryPlayer _Player;
	ImagesDialog _ImagesDialog;

	void Start()
	{
		_ImagesDialog = ImagesDialog.Instance;

		TextAsset a = Resources.Load("story") as TextAsset;
		Chunk c = Chunk.Load(a.bytes);

		_Player = new StoryPlayer();
		_Player.Load(c);
		_Player.BuildFlow();
		TextureManager.Singleton().Build(_Player.ResourceBox);

		StartCoroutine(AssigningUnits());
	}

	IEnumerator AssigningUnits()
	{
		yield return 0;
		_ImagesDialog.Setup(_Player.CurrentImages);
	}
}
