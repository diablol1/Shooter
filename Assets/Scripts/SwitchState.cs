using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchState : MonoBehaviour {

	public KeyCode key;
	public GameObject state;

	public int timeScale;

	public void Execute() {
		Time.timeScale = timeScale;

		state.SetActive (true);
		gameObject.SetActive (false);
	}
}
