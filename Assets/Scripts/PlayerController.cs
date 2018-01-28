using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[HideInInspector]
	public int Influence;

	public static PlayerController instance;

	private Rigidbody2D rb;
	private Vector2 vel;

	public float speed;


	private void Awake()
	{
		instance = this;
		Influence = 1;

		rb = GetComponent<Rigidbody2D> ();


	}

	private void Start(){

		InGameController.instance.totalInfluence += Influence;
	}

	private void Update()
	{
        vel.x = Input.GetAxisRaw ("Horizontal");
        vel.y = Input.GetAxisRaw ("Vertical");
        vel.Normalize();
	}

	private void FixedUpdate()
	{
		if (vel.magnitude != 0) {
			rb.isKinematic = false;
			float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		}else
			rb.isKinematic = true;

		Vector2 nVel = vel;
		nVel *= speed;
		rb.velocity = nVel;
	}

    private void OnTriggerExit2D(Collider2D col)
    {
        EnemyController enemy = col.gameObject.GetComponent<EnemyController> ();

        if (enemy != null && col == enemy._smallCollider) {
            enemy.HideInfluenceText ();
        }
    }

	private void OnTriggerEnter2D(Collider2D col)
	{
		ProspectController prosp = col.gameObject.GetComponent<ProspectController> ();
		EnemyController enemy = col.gameObject.GetComponent<EnemyController> ();

		if (prosp != null && col == prosp._smallCollider) {
            if (!prosp._converted || prosp.enemy != null && this.Influence >= prosp.enemy.Influence && !prosp.enemy._converted) {
                Influence += prosp.Follow (this);
                UIController.instance.SetInfluence (Influence);
                if (prosp.enemy != null) {
                    prosp.enemy.Influence -= prosp.Influence;
                }
            }
		}

		if (enemy != null && col == enemy._smallCollider) {
            enemy.ShowInfluenceText ();
            if (!enemy._converted && this.Influence >= enemy.Influence) {
				this.Influence += enemy.Follow (this);
				UIController.instance.SetInfluence (Influence);
            }
		}
	}

	public void DecInfluence(int value)
	{
		Influence -= value;
		UIController.instance.SetInfluence (Influence);
		UIController.instance.UpdateInfluence ();
	}
}
