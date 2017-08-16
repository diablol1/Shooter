using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesListOption : MonoBehaviour {

	public string gameName;
	public int levelIndex;

	public void OnChoose() {
		ChangeLevel.CurrentLevelIndex = levelIndex;
		GamesManagingState.CurrentGameName = gameName;

		SceneManager.LoadScene (ChangeLevel.GetCurrentLevelPath());
	}
}
