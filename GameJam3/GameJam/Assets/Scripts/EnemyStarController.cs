using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStarController : MonoBehaviour {
	public float speed;

	public playerController player;
	//public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	//public int pointsForKill;
	public int damageToGive;
	public float rotationSpeed;
	private Rigidbody2D myrigidbody2D;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<playerController> ();
		myrigidbody2D = GetComponent<Rigidbody2D> ();

		if (player.transform.position.x < transform.position.x) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	}

	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {

			//Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			//ScoreManager.AddPoints (pointsForKill);

			HealthManager.HurtPlayer (damageToGive);
		}

		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);

	}
}
