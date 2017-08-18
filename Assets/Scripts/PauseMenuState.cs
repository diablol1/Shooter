using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuState : MonoBehaviour {

	public PlayState play;

	public Text currentLevelText;

	public void OnClickResume() {
		Resume ();
	}

	public void OnClickReset() {
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void OnClickMainMenu() {
		SceneManager.LoadScene ("Scenes/MainMenu");
	}

	void OnEnable() {
		currentLevelText.text = "Level: " + ChangeLevel.CurrentLevelIndex.ToString() + "/" + ChangeLevel.NumberOfLevels.ToString();
	}

	void Update() {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Resume ();
		}
	}

	void Resume() {
		play.gameObject.SetActive (true);
		gameObject.SetActive (false);
		Time.timeScale = 1;
	}
}
