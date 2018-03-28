using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float moveSpeed = 10f;

	void Update () {
		var moveX = moveSpeed * Time.deltaTime;
		var moveY = 0f;
		var moveZ = 0f;
		transform.Translate(moveX, moveY, moveZ);
	}
}
