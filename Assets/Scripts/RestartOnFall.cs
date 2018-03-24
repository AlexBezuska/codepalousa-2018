using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartOnFall : MonoBehaviour {

	public float waitTime = 5.0f;

	void OnCollisionEnter(Collision other) {
		
		if (other.gameObject.tag == "Restart"){
			StartCoroutine (RestartLevel ());
		}
	}

	IEnumerator RestartLevel( ){
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel(Application.loadedLevel);
	}
}
