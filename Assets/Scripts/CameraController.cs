using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform target;
	public float smoothTime;
	private Vector3 velocity = Vector3.zero;

	private void FixedUpdate()
	{
		Vector3 newPosition = Vector3.SmoothDamp (transform.position, target.position, ref velocity, smoothTime);
		transform.SetPositionAndRotation (newPosition, Quaternion.identity);
		transform.Translate (new Vector3 (0, 0, -10));
	}
}
