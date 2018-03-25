using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[Range(1,100)]
	public float moveSpeed = 10f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		var moveX = moveSpeed * Time.deltaTime;
		var moveY = 0f;
		var moveZ = 0f;
		transform.Translate(moveX, moveY, moveZ);
	}
}
