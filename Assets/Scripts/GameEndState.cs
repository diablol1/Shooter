using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndState : MonoBehaviour {

	public void OnClickMainMenu() {
		SceneManager.LoadScene ("Scenes/MainMenu");
	}

	public void OnClickExit() {
		Application.Quit ();
	}
}
