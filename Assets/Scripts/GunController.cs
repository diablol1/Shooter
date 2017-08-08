using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour {

	public Transform bulletSpawn;
	public GameObject bulletPrefab;

	public float bulletForwardForce;
	public float bulletExistenceTime;

	int ammo;
	public Text ammoText;

	void Update () {
		//Left button
		if (Input.GetMouseButtonDown(0) && ammo > 0) {
			GameObject bullet = Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
			bullet.GetComponent<Rigidbody> ().AddForce (bulletSpawn.forward * bulletForwardForce);

			Destroy (bullet, bulletExistenceTime);

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