using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Shootable {

	public GameObject ammoPackPrefab;

	public int health;

	public float distanceToStartAttacking;

	public float closestDistanceToPlayer;

	public float rotationSpeed;

	public float walkSpeed;

	public float shootingInterval;

	public Transform player;

	float timeSinceLastShot;

	bool attacked;

	void Update () {
		if(Vector3.Distance(player.position, transform.position) <= distanceToStartAttacking || attacked) {
			Vector3 direction = player.position - transform.position;

			RotateTowardPlayer (direction);

			if(direction.magnitude >= closestDistanceToPlayer)
				MoveTowardPlayer ();

			timeSinceLastShot += Time.deltaTime;
			if (timeSinceLastShot >= shootingInterval) {
				timeSinceLastShot = 0f;
				Shoot ();
			}
		}
	}

	void RotateTowardPlayer(Vector3 playerDirection) {
		Vector3 direction = player.position - transform.position;
		direction.y = 0;
		direction.x *= Random.Range (0.95f, 1.05f); //Rotate little bit to left/right

		transform.rotation = Quaternion.Slerp (
			transform.rotation,
			Quaternion.LookRotation (direction),
			rotationSpeed * Time.deltaTime);
	}

	void MoveTowardPlayer() {
		transform.Translate (Vector3.forward * walkSpeed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Bullet") {
			Destroy (collision.collider.gameObject);
			health--;

			if (health == 0) {
				Instantiate (ammoPackPrefab, transform.position, Quaternion.identity);
				Destroy (gameObject);
			}

			attacked = true;
		}
	}
}