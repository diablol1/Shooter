using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GamesList : MonoBehaviour {

	public VerticalLayoutGroup buttonsGroup;
	public Button buttonPrefab;

	void Start() {
		LoadFromFile ("Saves.txt");
	}

	void LoadFromFile(string path) {
		string[] lines = File.ReadAllLines (path);

		foreach (string line in lines) {
			string[] pair = line.Split (' ');

			Add (pair [0], int.Parse(pair[1]));
		}
	}

	void Add(string name, int levelIndex) {
		Button button = Instantiate (buttonPrefab, Vector3.zero, Quaternion.identity);

		button.GetComponentInChildren<Text> ().text = "Name: " + name +
			"\n" +
			"Level: " + levelIndex.ToString ();

		button.GetComponentInChildren<GamesListOption> ().gameName = name;
		button.GetComponentInChildren<GamesListOption> ().levelIndex = levelIndex;

		button.transform.SetParent (buttonsGroup.transform, false);
	}
}