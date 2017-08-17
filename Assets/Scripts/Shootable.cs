using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {

	public Transform bulletSpawn;
	public GameObject bulletPrefab;

	const float bulletForwardForce = 2500;
	const float bulletExistenceTime = 4.0f;

	GameObject instantiatedObjects;

	protected void Awake() {
		instantiatedObjects = GameObject.Find ("InstantiatedObjects");
	}

	public void Shoot() {
		GameObject bullet = Instantiate (bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation,
			instantiatedObjects.transform);
		bullet.GetComponent<Rigidbody> ().AddForce (bulletSpawn.forward * bulletForwardForce);

		Destroy (bullet, bulletExistenceTime);
	}
}