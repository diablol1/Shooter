using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Shootable {

	public GameObject ammoPackPrefab;

	int health = 3;

	const float rotationSpeed = 100.0f;

	const float walkSpeed = 10.0f;

	const float alarmRadius = 25.0f;

	const float distanceToFollow = 40.0f;

	const float distanceToAttack = 30.0f;

	const float notSeenTimeToStopFollowing = 10.0f;

	const float closestDistanceToPlayer = 5.0f;

	const float shootingInterval = 0.25f;

	Transform player;

	float timeSinceLastShot;

	float timeSinceNotSeenPlayer;

	bool attacked;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {

		timeSinceNotSeenPlayer += Time.deltaTime;
		timeSinceLastShot += Time.deltaTime;

		float distance = Vector3.Distance (player.position, transform.position);
		Vector3 direction = player.position - transform.position;

		if (distance <= distanceToFollow) {
			timeSinceNotSeenPlayer = 0;
			Follow (direction);
		} else if (attacked) {
			Follow (direction);
		}

		if (distance <= distanceToAttack) {
			if (timeSinceLastShot >= shootingInterval) {
				timeSinceLastShot = 0;
				Shoot ();
			}
		}

		if (timeSinceNotSeenPlayer >= notSeenTimeToStopFollowing) {
			attacked = false;
		}
	}

	void Follow(Vector3 direction) {
		RotateTowardPlayer (direction);

		if(direction.magnitude >= closestDistanceToPlayer)
			MoveTowardPlayer ();
	}

	void RotateTowardPlayer(Vector3 direction) {
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

			timeSinceNotSeenPlayer = 0;
			attacked = true;

			AlarmCloseEnemies ();
		}
	}

	void AlarmCloseEnemies() {
		Collider[] colliders = Physics.OverlapSphere(transform.position, alarmRadius);

		foreach (Collider c in colliders) {
			if (c.tag == "Enemy") {
				c.gameObject.GetComponent<Enemy> ().attacked = true;
			}
		}
	}
}