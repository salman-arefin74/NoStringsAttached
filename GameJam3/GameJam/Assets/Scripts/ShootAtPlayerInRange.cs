using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayerInRange : MonoBehaviour {

	public float PlayerRange;
	public GameObject enemyStar;
	public playerController player;
	public Transform launchPoint;

	void Start () {
		player = FindObjectOfType<playerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (new Vector3 (transform.position.x - PlayerRange, transform.position.y, transform.position.z), new Vector3 (transform.position.x + PlayerRange, transform.position.y, transform.position.z));

		if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + PlayerRange) {
			Instantiate (enemyStar, launchPoint.position, launchPoint.rotation);
		}

		if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - PlayerRange) {
			Instantiate (enemyStar, launchPoint.position, launchPoint.rotation);
		}
	
	}
}
