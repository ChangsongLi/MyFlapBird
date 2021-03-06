﻿using UnityEngine;
using System.Collections;

public class GroundMover : MonoBehaviour {

	Rigidbody2D player;

	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");

		if (player_go == null) {
			Debug.LogError ("Could not find player object");
			return;
		}

		player = player_go.GetComponent<Rigidbody2D>();;
	}

	void FixedUpdate(){
		float vel = player.velocity.x * 0.75f;
		transform.position += Vector3.right * vel * Time.deltaTime;
	}
}
