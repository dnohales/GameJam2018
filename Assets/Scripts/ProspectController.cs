using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProspectController : MonoBehaviour 
{

	public int Influence;

	public bool _converted;
	private bool _follow;

	public float speed;

	//[SerializeField]
	//private Material _normalMaterial;
	[SerializeField]
	private Material _convertedMaterial;

	private Vector3 PositionToGo;
	private PlayerController player;
	public SphereCollider _smallCollider;
	public SphereCollider _bigCollider;

	private Rigidbody rb;


	private void Awake()
	{
		rb = GetComponent<Rigidbody> ();
		Renderer ren = gameObject.GetComponent<Renderer> ();
		//ren.material = _convertedMaterial;
		_follow = false;
		_converted = false;
	}

	public int Follow()
	{
		_converted = true;

		if (_convertedMaterial != null) {
			Renderer ren = gameObject.GetComponent<Renderer> ();
			ren.material = _convertedMaterial;
		}
		return Influence;
	}

	private void FixedUpdate()
	{
		if (!_converted)
			return;
		if (!_follow)
			return;
		float dis = Vector3.Distance (gameObject.transform.position, PositionToGo);

		if (dis > 0.5f) {
			rb.velocity = GetVel ();
		} else {
			PositionToGo = player.gameObject.transform.position;
		}

	}

	private void OnTriggerExit(Collider col)
	{
		if (col.gameObject.name != "Player")
			return;
		if (!_converted)
			return;
		if (col != col.gameObject.GetComponent<PlayerController> ()._smallCollider)
			return;

		_follow = true;
		rb.isKinematic = false;
		PositionToGo = col.gameObject.transform.position;
	}

	private void OnTriggerEnter(Collider col)
	{		
		if (col.gameObject.name != "Player")
			return;
		if (!_converted)
			return;

		if (player == null)
			player = col.gameObject.GetComponent<PlayerController> ();

		if (col != player._smallCollider)
			return;

		rb.velocity = Vector3.zero;
		_follow = false;
	}

	private Vector3 GetVel()
	{
		Vector3 vel = PositionToGo - gameObject.transform.position;
		vel.Normalize ();
		return vel * speed;
	}

}
