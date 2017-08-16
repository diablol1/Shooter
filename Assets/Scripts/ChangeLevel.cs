using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ChangeLevel : MonoBehaviour {

	const string levelsDirectory = "Scenes/Levels/";
	const int numberOfLevels = 2;

	public static int CurrentLevelIndex = 1;

	void OnTriggerEnter(Collider col) {
		
		int numberOfEnemies = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		if (col.gameObject.tag == "Player" && numberOfEnemies == 0) {
			
			CurrentLevelIndex++;

			if (CurrentLevelIndex <= numberOfLevels) {
				GamesManagingState.UpdateSave ();
				SceneManager.LoadScene (GetCurrentLevelPath());
			}

		}
	}

	public static string GetCurrentLevelPath() {
		return levelsDirectory + "Level" + CurrentLevelIndex.ToString ();
	}
}