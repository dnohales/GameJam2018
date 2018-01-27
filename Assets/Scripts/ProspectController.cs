using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProspectController : MonoBehaviour
{
	public int Influence;
	public bool _converted;
	public float speed;

	private PlayerController player;
	public CircleCollider2D _smallCollider;

	private Rigidbody2D rb;


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
		_converted = false;
	}

    public int Follow(PlayerController _player)
	{
		_converted = true;
        player = _player;
        rb.isKinematic = false;

		return Influence;
	}

	private void FixedUpdate()
	{
        if (!_converted)
			return;

        Vector2 vector = rb.velocity.normalized;

        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        float dis = Vector2.Distance (gameObject.transform.position, player.gameObject.transform.position);

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
