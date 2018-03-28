using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

	public Transform target;
	public float height = 10;

	void LateUpdate () {
		transform.position = new Vector3(target.position.x,target.position.y + height,transform.position.z);
	}
}