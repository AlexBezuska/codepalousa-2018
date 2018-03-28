using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public AudioClip[] jumpSounds;
	public float jumpVelocity;

	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	Rigidbody rb;
	public bool grounded = true;



	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
		
	void Update () {

		var jumpButtonPushed = Input.GetButton ("Jump") || Input.GetMouseButton(0) || Input.touchCount > 0;

		if (jumpButtonPushed && grounded) {
			grounded = false;
			rb.velocity = Vector3.up * jumpVelocity;
			SoundManager.Instance.Play (jumpSounds);
		}


		if (rb.velocity.y < 0) {
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !jumpButtonPushed) {
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Ground"){
			grounded = true;
		}
	}
		
}
