using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public AudioSource background;
	public AudioSource wololo;

	private void Awake()
	{
		instance = this;
		if(background != null)
			background.Play ();
	}

	public void PlayWololo()
	{
		if (wololo != null)
			wololo.Play ();
	}

}
