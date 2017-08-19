using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAmmoPack : MonoBehaviour {

	public int minAmmo;
	public int maxAmmo;

	public GameObject gun;

	public AudioClip audioClip;

	AudioSource audioSource;

	void Awake() {
		audioSource = GetComponent<AudioSource> ();
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.collider.tag == "AmmoPack") {
			Destroy (hit.collider.gameObject);

			gun.GetComponent<GunController> ().ammoCounter.Add (Random.Range (minAmmo, maxAmmo));

			audioSource.PlayOneShot (audioClip);
		}
	}
}