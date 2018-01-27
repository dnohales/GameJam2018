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

		InputListener.Events.OnInputLeft += GetMoveHorValues;
		InputListener.Events.OnInputRight +=GetMoveHorValues;
		InputListener.Events.OnInputUp += GetMoveVerValues;
		InputListener.Events.OnInputDown += GetMoveVerValues;

		rb = GetComponent<Rigidbody> ();
	}

	private void GetMoveHorValues(float x)
	{
		vel = new Vector2 (x,vel.y);
	}

	private void GetMoveVerValues(float y)
	{
		vel = new Vector2 (vel.x,y);
	}

	private void Update()
	{
		// culpa de fran
		//vel.Normalize ();
	}

	private void FixedUpdate()
	{
		vel.Normalize ();
		vel *= speed;
		rb.velocity = vel;
	}
}
