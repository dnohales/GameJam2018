using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
	public PlayerController Player;
	public Text influence;
	private int currentInfluence;

	public Text Timer;

	public GameObject EndPanelLose;
	public GameObject EndPanelWin;

	public static UIController instance;

	private void Start()
	{		
		instance = this;
		currentInfluence = Player.Influence;
		influence.text = currentInfluence.ToString();
	}

	private void Update(){
		if (InGameController.instance == null)
			return;

		if (Timer == null)
			return;

		Timer.text = InGameController.instance.Timer.ToString("##.##");
	}
	

	public void AddInfluence(int value)
	{	
		currentInfluence += value;
		UpdateInfluence ();
	}

	public void UpdateInfluence()
	{
		influence.text = currentInfluence.ToString ();
	}

	public void SetInfluence(int value)
	{
		currentInfluence = value;
		UpdateInfluence ();
	}	

	public void DecInfluence(int value)
	{	
		currentInfluence -= value;
		UpdateInfluence ();
	}

	public void ShowEnd()
	{
		if (PlayerController.instance.Influence >= InGameController.instance.InfluenceToWin) {
			if (EndPanelWin != null)
				EndPanelWin.SetActive (true);
		} else {
			if (EndPanelLose != null) {
				EndPanelLose.SetActive (true);
			}
		}
	}
}
