﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProspectController : MonoBehaviour
{
	public int Influence;
	public bool _converted;
	public float speed;

	private PlayerController player;
	private EnemyController enemy;
	public CircleCollider2D _smallCollider;

	private Rigidbody2D rb;


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
		_converted = false;
	}

    public int Follow(PlayerController _player)
	{
		if (enemy != null)
			enemy = null;
		
		_converted = true;
        player = _player;
        rb.isKinematic = false;

		return Influence;
	}

	public int Follow(EnemyController enemy)
	{
		if (player!=null)
			player = null;
		
		_converted = true;
		this.enemy = enemy;
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
		float dis = 0;
		if (player != null)
        	dis = Vector2.Distance (gameObject.transform.position, player.gameObject.transform.position);
		else if (enemy != null)
			dis = Vector2.Distance (gameObject.transform.position, enemy.gameObject.transform.position);

		if (dis > 3f) {
			rb.velocity = GetVel ();
        } else {
            rb.velocity = Vector3.zero;
        }
	}

	private Vector3 GetVel()
	{
		Vector3 vel = new Vector3 ();
		if (player != null)
			vel = player.transform.position - gameObject.transform.position;
		else if  (enemy != null)
			vel = enemy.transform.position - gameObject.transform.position;
		
		vel.Normalize ();
		return vel * speed;
	}

}
