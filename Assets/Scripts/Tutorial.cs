using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{

	private int tutorial;
	// Use this for initialization
	void Start ()
	{
		tutorial = PlayerPrefs.GetInt (GamePrefs.TUTORIAL, 0);
		if (tutorial == 0) {
			tutorial = 1;
			PlayerPrefs.SetInt (GamePrefs.TUTORIAL, 1);
			PlayerPrefs.Save ();
			Time.timeScale = 0;
		} else {
			gameObject.SetActive (false);
		}
	}

	public void ClosePanel ()
	{
		gameObject.SetActive (false);
		Time.timeScale = 1;
	}

}
