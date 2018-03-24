using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distancebetween;

	private float platformWidth;


	void Start () {
		platformWidth = thePlatform.GetComponent<BoxCollider> ().size.x;
	}


	void Update () {
		if (transform.position.x < generationPoint.position.x) {
			transform.position = new Vector3 (transform.position.x + platformWidth + distancebetween, transform.position.y);

			Instantiate (thePlatform, transform.position, transform.rotation);
		}
	}
}
