using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : MonoBehaviour {
	
	public void OnClickPlay() {
		Time.timeScale = 1;
		SceneManager.LoadScene ("Scenes/TestScene"); //Loading saves will be here in future
	}

	public void OnClickExit() {
		Application.Quit ();
	}
}
