using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public static LevelManager instance;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Start ()
	{
		CheckLevel ();
	}


	private void CheckLevel ()
	{
		if (SceneManager.GetActiveScene ().name == GamePrefs.SPLASHSCREEN) {
			Invoke ("LoadMainMenu", 3.5f);
		}
	}

	public void LoadLevel (string name)
	{
		SceneManager.LoadScene (name);

	}

	public void LoadMainMenu ()
	{
		SceneManager.LoadScene (GamePrefs.MAINMENU);
		Time.timeScale = 1;
	}

	public void QuitRequest ()
	{
		
		Application.Quit ();
	}

}
