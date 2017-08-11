using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLeftTimeText : MonoBehaviour {

	CountdownTimer timer;

	void Start() {
		timer = GetComponent<CountdownTimer> ();
	}

	void Update() {
		GetComponent<Text> ().text = "Time: " + timer.GetInSeconds ().ToString ();
	}
}
