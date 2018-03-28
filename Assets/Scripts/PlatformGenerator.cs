using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject[] platforms;
	public Transform generationPoint;

	public float heightVariance;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private float platformWidth;


	void Update () {
		var index = Random.Range (0, platforms.Length);
		var platformPick = platforms[index];

		var distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
		var yPosition = Random.Range (transform.position.y - heightVariance, transform.position.y  + heightVariance);
		if (transform.position.x < generationPoint.position.x) {
			transform.position = new Vector3 (transform.position.x + 10 + distanceBetween, yPosition);

			Instantiate (platformPick, transform.position, transform.rotation);
		}
	}
}
