using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody rb;
	private Vector2 vel;

	public float speed;


	private void Awake()
	{

		InputListener.Events.On
		rb = GetComponent<Rigidbody> ();
	}


	private void Update()
	{
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		vel = new Vector2 (x, y);
		// culpa de fran
		//vel.Normalize ();
		vel *= speed;
	}

	private void FixedUpdate()
	{
		rb.velocity = vel;
	}
}
