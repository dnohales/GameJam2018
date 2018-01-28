using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform target;
	public float smoothTime;
	private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        transform.SetPositionAndRotation (AdjustZoomForVector (target.position), Quaternion.identity);
    }

	private void FixedUpdate()
	{
		Vector3 newPosition = Vector3.SmoothDamp (transform.position, target.position, ref velocity, smoothTime);
        transform.SetPositionAndRotation (AdjustZoomForVector (newPosition), Quaternion.identity);
	}

    private Vector3 AdjustZoomForVector(Vector3 vec)
    {
        return new Vector3 (vec.x, vec.y, -1);
    }
}
