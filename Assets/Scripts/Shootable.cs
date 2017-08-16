using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {

	public Transform bulletSpawn;
	public GameObject bulletPrefab;

	const float bulletForwardForce = 2500;
	const float bulletExistenceTime = 4.0f;

	public void Shoot() {
		GameObject bullet = Instantiate (bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation,
			GameObject.FindGameObjectWithTag("BulletsContainer").transform);
		bullet.GetComponent<Rigidbody> ().AddForce (bulletSpawn.forward * bulletForwardForce);

		Destroy (bullet, bulletExistenceTime);
	}
}