using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : MonoBehaviour {

	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			GetComponent<SwitchState> ().Execute ();
		}
	}
}
