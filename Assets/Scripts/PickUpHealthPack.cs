using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealthPack : MonoBehaviour {

	public int min;
	public int max;

	public AudioClip audioClip;

	PlayerController player;

	AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
		player = GetComponent<PlayerController> ();
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.collider.tag == "HealthPack") {
			Destroy (hit.collider.gameObject);

			player.healthCounter.Add(Random.Range (min, max));

			audioSource.PlayOneShot (audioClip);
		}
	}
}
