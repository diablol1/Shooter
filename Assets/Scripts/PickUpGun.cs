using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour {

	public Transform spawn;
	public GameObject handedGun;

	bool hasGun;

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.collider.tag == "LyingGun" && !hasGun) {
			hasGun = true;
			Destroy (hit.collider.gameObject);

			handedGun.SetActive (true);
			handedGun.transform.position = spawn.position;
			handedGun.transform.rotation = spawn.rotation;

			handedGun.transform.SetParent (transform.Find ("Head"));
		}
	}
}