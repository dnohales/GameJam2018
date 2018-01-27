using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProspectController : MonoBehaviour
{
	public int Influence;
	public bool _converted;
	public float speed;

	[SerializeField]
	private Material _convertedMaterial;

	private PlayerController player;
	public SphereCollider _smallCollider;
	public SphereCollider _bigCollider;

	private Rigidbody rb;


	private void Awake()
	{
		rb = GetComponent<Rigidbody> ();
		Renderer ren = gameObject.GetComponent<Renderer> ();
		_converted = false;
	}

    public int Follow(PlayerController _player)
	{
		_converted = true;
        player = _player;
        rb.isKinematic = false;

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

        Vector3 vector = rb.velocity.normalized;

        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        float dis = Vector3.Distance (gameObject.transform.position, player.gameObject.transform.position);

		if (dis > 3f) {
			rb.velocity = GetVel ();
        } else {
            rb.velocity = Vector3.zero;
        }
	}

	private Vector3 GetVel()
	{
        Vector3 vel = player.transform.position - gameObject.transform.position;
		vel.Normalize ();
		return vel * speed;
	}

}
