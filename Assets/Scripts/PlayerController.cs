using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	
	private Rigidbody rb;
	private Vector2 vel;

	public float speed;
	public SphereCollider _smallCollider;
	public SphereCollider _bigCollider;

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
		vel.x = x;
	}

	private void GetMoveVerValues(float y)
	{
		vel.y = y;
	}

	private void Update()
	{
		// culpa de fran
		//vel.Normalize ();
	}

	private void FixedUpdate()
	{
		Vector2 nVel = vel;
		nVel *= speed;
		rb.velocity = nVel;
	}

	private void OnTriggerEnter(Collider col)
	{
		ProspectController prosp = col.gameObject.GetComponent<ProspectController> ();
		if (prosp != null && col == prosp._smallCollider) {
			prosp.Follow ();
		}

			
	}
}
