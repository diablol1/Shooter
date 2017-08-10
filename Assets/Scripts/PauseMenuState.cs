using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuState : MonoBehaviour {

	public void OnClickResume() {
		GetComponent<SwitchState> ().Execute ();
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
			GetComponent<SwitchState> ().Execute ();
		}
	}
}
