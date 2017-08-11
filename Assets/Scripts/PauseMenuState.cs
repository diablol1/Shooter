using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuState : MonoBehaviour {

	public PlayState play;

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
