using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
	public PlayerController Player;
	public Text influence;
	private int currentInfluence;

	public static UIController instance;

	private void Start()
	{		
		instance = this;
		currentInfluence = Player.Influence;
		influence.text = currentInfluence.ToString();
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
}
