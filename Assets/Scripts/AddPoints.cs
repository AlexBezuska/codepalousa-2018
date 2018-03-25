using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		other.gameObject.GetComponent<Score> ().AddPoints ();
	}

}
