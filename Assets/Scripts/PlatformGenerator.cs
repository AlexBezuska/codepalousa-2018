using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;

	public float heightVariance;


	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private float platformWidth;


	void Start () {
		platformWidth = thePlatform.GetComponent<BoxCollider> ().size.x;
	}


	void Update () {
		var distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
		var yPosition = Random.Range (transform.position.y - heightVariance, transform.position.y  + heightVariance);
		if (transform.position.x < generationPoint.position.x) {
			transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween, yPosition);

			Instantiate (thePlatform, transform.position, transform.rotation);
		}
	}
}
