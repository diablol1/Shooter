using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : MonoBehaviour {

	public GamesManagingState savesManaging;
	
	public void OnClickPlay() {
		savesManaging.gameObject.SetActive (true);
		gameObject.SetActive (false);
	}

	public void OnClickExit() {
		Application.Quit ();
	}
}
