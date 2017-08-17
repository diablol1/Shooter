using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : MonoBehaviour {

	public PlayerController player;
	public CountdownTimer leftTime;

	public PauseMenuState pauseMenu;

	void Start() {
		Time.timeScale = 1;
	}

	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			pauseMenu.gameObject.SetActive (true);
			gameObject.SetActive (false);
			Time.timeScale = 0;
		} else if (player.healthCounter.GetValue() <= 0 || leftTime.GetInSeconds() == 0) {
			SceneManager.LoadScene ("Scenes/GameOver");
		}
	}

	void OnEnable() {
		Cursor.lockState = CursorLockMode.Locked;
	}

	void OnDisable() {
		Cursor.lockState = CursorLockMode.None;
	}
}
