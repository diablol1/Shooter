using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : MonoBehaviour {

	public void OnClickPlayAgain() {
		SceneManager.LoadScene ("Scenes/TestScene"); //TODO: Loading from save
	}

	public void OnClickMainMenu() {
		SceneManager.LoadScene ("Scenes/MainMenu");
	}
}