using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	float flapSpeed = 100f;
	float forwardVelocity = 1f;
	bool didFlap = false;

	bool dead = false;

	Animator[] animator;

	// Use this for initialization
	void Start () {
		animator = (transform.GetComponentsInChildren<Animator> ());
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			didFlap = true;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (dead)
			return;

		GetComponent<Rigidbody2D> ().AddForce (Vector2.right * forwardVelocity);

		if (didFlap) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * flapSpeed);

			foreach(Animator anm in animator)
			{
				anm.SetTrigger ("DoFlap");
			}

			didFlap = false;
		}

		if (GetComponent<Rigidbody2D> ().velocity.y > 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} else {
			float angle = Mathf.Lerp (0, -90, -GetComponent<Rigidbody2D> ().velocity.y / 3f);
			transform.rotation = Quaternion.Euler (0, 0, angle);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		foreach(Animator anm in animator)
		{
			anm.SetTrigger ("Death");
			dead = true;
			return;
		}
	}
}
