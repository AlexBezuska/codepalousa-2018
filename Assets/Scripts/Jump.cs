using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {


	public float jumpVelocity;

	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	Rigidbody rb;
	public bool grounded = true;

	// Code run when gameobject this script is on is created
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}


	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ground"){
			grounded = true;
		}
	}


	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Jump") && grounded) {
			grounded = false;
			rb.velocity = Vector3.up * jumpVelocity;
		}


		if (rb.velocity.y < 0) {
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !Input.GetButton ("Jump")) {
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}
}
