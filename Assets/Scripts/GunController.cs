using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : Shootable {
	
	int ammo;
	public Text ammoText;

	void Update () {
		//Left button
		if (Input.GetMouseButtonDown(0) && ammo > 0) {
			Shoot ();

			ammo--;
			UpdateAmmoText ();
		}
	}

	public void AddAmmo(int n) {
		ammo += n;
	}

	public void UpdateAmmoText() {
		ammoText.text = "Ammo: " + ammo.ToString ();
	}
}