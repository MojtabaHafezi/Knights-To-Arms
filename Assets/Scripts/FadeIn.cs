using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{

	private float fadeinTime;


	private Image fadePanel;
	private Color color;


	void Awake ()
	{
		color = Color.black;
		fadePanel = GetComponent <Image> ();

		fadeinTime = 1f;
		if (SceneManager.GetActiveScene ().name == GamePrefs.SPLASHSCREEN)
			fadeinTime = 1.5f;
		
	}

	void Update ()
	{
		
		if (Time.timeSinceLevelLoad < fadeinTime) {
			float alphaToChange = Time.deltaTime / fadeinTime; // wie viel % muss nach dem Frame vermindert werden?
			color.a -= alphaToChange;
			fadePanel.color = color;
		} else {
			this.gameObject.SetActive (false);

		}
		
	}


}
