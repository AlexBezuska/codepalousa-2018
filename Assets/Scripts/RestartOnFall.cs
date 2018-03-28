using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartOnFall : MonoBehaviour {

	public float resetZone = -50;

	void Update(){
		if (transform.position.y < resetZone) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
