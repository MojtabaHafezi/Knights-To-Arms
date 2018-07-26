using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class MusicManager : MonoBehaviour
{
	public static MusicManager instance;
	public AudioClip[] levelChangeMusicArray;
	private AudioSource audioSource;
	private bool mute;
	

	// Use this for initialization
	void Awake ()
	{
		mute = false;
		MakeSingleton ();
		audioSource = GetComponent <AudioSource> ();
	
	}

	void OnLevelWasLoaded (int level)
	{
		if (levelChangeMusicArray [level] != null) {
			if (audioSource.clip != levelChangeMusicArray [level]) {
				audioSource.clip = levelChangeMusicArray [level];
				audioSource.loop = true;
				if (level == 5) {
					audioSource.loop = false;
				}
				if (!audioSource.isPlaying)
					audioSource.Play ();
			}
		}
	}

	void MakeSingleton ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			if (instance == null) {
				instance = this;
				DontDestroyOnLoad (gameObject);
			}
		}
	}

	public void ChangeMusicStatus ()
	{
		mute = !mute;
		instance.audioSource.mute = mute;
		//audioSource.mute = mute;
	}
}
