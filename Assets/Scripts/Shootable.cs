using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {

	public Transform bulletSpawn;
	public GameObject bulletPrefab;

	public float bulletForwardForce;
	public float bulletExistenceTime;

	public void Shoot() {
		GameObject bullet = Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation, GameObject.Find("BulletsContainer").transform);
		bullet.GetComponent<Rigidbody> ().AddForce (bulletSpawn.forward * bulletForwardForce);

		Destroy (bullet, bulletExistenceTime);
	}
}