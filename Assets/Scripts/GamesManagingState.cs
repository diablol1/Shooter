using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GamesManagingState : MonoBehaviour {

	public MainMenuState mainMenu;
	public GameObject newGameForm;

	public static string CurrentGameName;

	public void OnClickMainMenu() {
		mainMenu.gameObject.SetActive (true);
		gameObject.SetActive (false);
	}

	public void OnClickNewGame() {
		newGameForm.SetActive (true);
	}

	public static void UpdateSave() {
		string[] lines = File.ReadAllLines ("Saves.txt");

		for(int i = 0; i < lines.Length; i++) {
			if (lines [i].Contains (CurrentGameName))
				lines [i] = CurrentGameName + " " + ChangeLevel.CurrentLevelIndex.ToString ();
		}
			
		File.WriteAllLines ("Saves.txt", lines);
	}
}