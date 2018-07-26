using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{

	private MusicManager musicManager;
	private Slider slider;
	// Use this for initialization
	void Start ()
	{
		musicManager = FindObjectOfType <MusicManager> ();
		slider = GetComponent <Slider> ();
		slider.value = musicManager.GetComponentInParent <AudioSource> ().volume;
	}

	public void OnChangeSlider ()
	{
		musicManager.GetComponentInParent <AudioSource> ().volume = slider.value;
	}
}
