using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController : MonoBehaviour 
{
	public static InGameController instance;

	private float _gameStartTime;
	public float TimeToPlay;
	public int InfluenceToWin;
	public float Timer;

	public int totalInfluence;

	public bool GameIsRunning;

	public System.Action OnEndGame;

	private void Awake()
	{
		GameIsRunning = true;
		instance = this;
		_gameStartTime = Time.time;
		Timer = 0;
	}

	private void Update()
	{
		if (GameIsRunning) {
			Timer += Time.deltaTime;
			if (Timer > TimeToPlay || PlayerController.instance.Influence >= InfluenceToWin )
				GameIsRunning = false;
		} else {
			EndGame ();
		}			
	}

	private void EndGame()
	{
		UIController.instance.ShowEnd ();
		if (OnEndGame != null)
			OnEndGame ();
	}

}
