using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {

	public Transform bulletSpawn;
	public GameObject bulletPrefab;

	public AudioClip audioClip;

	const float bulletForwardForce = 2500;
	const float bulletExistenceTime = 4.0f;

	AudioSource audioSource;

	GameObject instantiatedObjects;

	protected void Awake() {
		audioSource = GetComponent<AudioSource> ();
		instantiatedObjects = GameObject.Find ("InstantiatedObjects");
	}

	public void Shoot() {
		GameObject bullet = Instantiate (bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation,
			instantiatedObjects.transform);
		bullet.GetComponent<Rigidbody> ().AddForce (bulletSpawn.forward * bulletForwardForce);

		Destroy (bullet, bulletExistenceTime);

		audioSource.PlayOneShot (audioClip);
	}
}