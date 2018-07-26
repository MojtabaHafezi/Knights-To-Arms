using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{
	private Slider slider;

	private bool isFinished = false;
	public float levelSeconds = 6;

	private LevelManager levelManager;


	// Use this for initialization
	void Start ()
	{
		slider = GetComponent <Slider> ();

		levelManager = GameObject.FindObjectOfType <LevelManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		if (!isFinished && Time.timeSinceLevelLoad >= levelSeconds) {
			isFinished = true;
			EndScreen ();
		}
	}

	void EndScreen ()
	{
		levelManager.LoadLevel ("03 Win");
	}


}
