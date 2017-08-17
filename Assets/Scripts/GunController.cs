using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : Shootable {

	public Counter ammoCounter;
	public Text ammoText;

	void Awake() {
		base.Awake ();

		ammoCounter = new Counter (ammoText, "Ammo: ", 0);
		gameObject.SetActive (false);
	}

	void Update () {
		//Left button
		if (Input.GetMouseButtonDown(0) && ammoCounter.GetValue() > 0) {
			Shoot ();

			ammoCounter.Subtract (1);
		}
	}
}