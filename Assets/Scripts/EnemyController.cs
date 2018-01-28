using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
	public int Influence;
	public bool _converted;
	public float speed;
    public float prowlSpeed;
    public List<Transform> prowlPath;

	public PlayerController player;
	public EnemyController enemy;
    private int currentProwlDestinationIndex;
	public CircleCollider2D _smallCollider;

	private Rigidbody2D rb;
    private Text influenceText;
    private RectTransform influencePanel;

	private void Awake()
	{
        if (prowlPath.Count > 0) {
            currentProwlDestinationIndex = 0;
        } else {
            currentProwlDestinationIndex = -1;
        }
		rb = GetComponent<Rigidbody2D> ();

		_converted = false;

        influencePanel = transform.Find("Canvas").Find("Panel").GetComponent<RectTransform> ();
        influenceText = influencePanel.Find("InfluenceText").GetComponent<Text> ();
        HideInfluenceText ();
	}

	private void Start()
	{
		InGameController.instance.totalInfluence += Influence;
		InGameController.instance.OnEndGame += Disable;
	}

	private void Disable()
	{
		InGameController.instance.OnEndGame -= Disable;
		gameObject.SetActive (false);
	}

    public void ShowInfluenceText()
    {
        influencePanel.gameObject.SetActive (true);
        influenceText.text = Influence.ToString ();
    }

    public void HideInfluenceText()
    {
        influencePanel.gameObject.SetActive (false);
    }

	private void OnTriggerEnter2D(Collider2D col)
	{
		ProspectController prosp = col.gameObject.GetComponent<ProspectController> ();

		if (prosp != null && col == prosp._smallCollider) {
            if ( prosp.player == null && !prosp._converted || prosp.player != null && Influence > prosp.player.Influence) {
                if (prosp.player != null)
                    PlayerController.instance.DecInfluence (prosp.Influence);
				Influence += prosp.Follow (this);
			}
		}
	}

	public int Follow(PlayerController _player) {
		if (enemy != null)
			enemy = null;

		SoundManager.instance.PlayWololo ();
		_converted = true;
		player = _player;
		rb.isKinematic = false;
        HideInfluenceText ();

		return Influence;
	}

	public int Follow(EnemyController enemy) {
		if (player!=null)
			player = null;

		SoundManager.instance.PlayWololo ();
		_converted = true;
		this.enemy = enemy;
		rb.isKinematic = false;
        HideInfluenceText ();

		return Influence;
	}

    private void FixedUpdate()
    {
        if (_converted) {
            UpdateMovementConverted ();
        } else {
            UpdateMovementProwl ();
        }
    }

    private void UpdateMovementConverted()
    {
        float dis = 0;
        Vector3 destination = new Vector3 ();
        if (player != null) {
            dis = Vector2.Distance (gameObject.transform.position, player.gameObject.transform.position);
            destination = player.gameObject.transform.position;
        } else if (enemy != null) {
            dis = Vector2.Distance (gameObject.transform.position, enemy.gameObject.transform.position);
            destination = enemy.gameObject.transform.position;
        }

        if (dis > 3f) {
            rb.velocity = GetVel (destination, speed);
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        } else {
            rb.velocity = Vector3.zero;
        }
    }

    private void UpdateMovementProwl()
    {
        if (currentProwlDestinationIndex >= 0) {
            Vector3 destination = prowlPath[currentProwlDestinationIndex].position;
            float dis = Vector2.Distance (gameObject.transform.position, destination);
            if (dis > 1f) {
                rb.velocity = GetVel (destination, prowlSpeed);
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            } else {
                currentProwlDestinationIndex++;
                if (currentProwlDestinationIndex == prowlPath.Count) {
                    currentProwlDestinationIndex = 0;
                }
            }
        }
    }

    private Vector3 GetVel(Vector3 destination, float speed)
    {
        Vector3 vel = destination - gameObject.transform.position;
        vel.Normalize ();
        return vel * speed;
    }
}
