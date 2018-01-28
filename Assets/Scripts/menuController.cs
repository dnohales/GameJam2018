using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuController : MonoBehaviour {

	// Use this for initialization

	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		exit ();
	}

	public void useInfoButton () {
		SceneManager.LoadScene (2);
	}

	public void useStartButton () {
		SceneManager.LoadScene (1);
	}

	public void useBackButton () {
		SceneManager.LoadScene (0);
	}

	public void useCreditButton () {
		SceneManager.LoadScene (4);
	}


	public void exit(){
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
	}
}
