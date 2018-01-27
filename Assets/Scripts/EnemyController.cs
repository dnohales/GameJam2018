using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	public int Influence;

	private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		ProspectController prosp = col.gameObject.GetComponent<ProspectController> ();
		if (prosp != null && col == prosp._smallCollider) {
			if ( Influence > PlayerController.instance.Influence) {
				Influence += prosp.Follow (this);
				PlayerController.instance.DecInfluence (prosp.Influence);
			}
		}
	}
}
