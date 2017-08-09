using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour {

	public int health;
	public Text healthText;	

	public float walkSpeed;
	public float mouseSensitivity;

	public GameObject head;

	CharacterController player;

	void Start () {
		UpdateHealthText ();
		player = GetComponent<CharacterController> ();
	}

	void Update () {
		float verticalMove = Input.GetAxis ("Vertical") * walkSpeed;
		float horizontalMove = Input.GetAxis ("Horizontal") * walkSpeed;

		float rotX = Input.GetAxis ("Mouse X") * mouseSensitivity;
		float rotY = Input.GetAxis ("Mouse Y") * mouseSensitivity;

		head.transform.Rotate (-rotY, 0, 0);

		transform.Rotate (0, rotX, 0);

		Vector3 move = new Vector3 (horizontalMove, 0, verticalMove);
		move = transform.rotation * move;

		player.SimpleMove (move);
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Bullet") {
			Destroy (collider.gameObject);
			health--;

			if (health == 0)
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

			UpdateHealthText ();
		}
	}

	void UpdateHealthText() {
		healthText.text = "Health: " + health.ToString ();
	}
}