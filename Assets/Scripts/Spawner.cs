using UnityEngine;
using System.Collections;
using System;
using System.Threading;


public class Spawner : MonoBehaviour
{

	public GameObject[] attackerArray;
	private float[] timerArray;
	private float randomiser;
	private float capSpawn;
	bool boss = false, hardMode = false;


	void Start ()
	{
		timerArray = new float[attackerArray.Length];
		for (int i = 0; i < timerArray.Length; i++) {
			timerArray [i] = 0;
		}

		randomiser = UnityEngine.Random.Range (1.3f, 8.8f);
		capSpawn = Mathf.RoundToInt (UnityEngine.Random.Range (0.5f, 4.5f));
	}

	// Update is called once per frame
	void Update ()
	{
//		foreach (GameObject thisAttacker in attackerArray) {
//			
//			if (IsTimeToSpawn (thisAttacker)) {
//				Spawn (thisAttacker);
//			}
//		}

		for (int i = 0; i < attackerArray.Length; i++) {
			if (IsTimeToSpawn (attackerArray [i], i)) {
				Spawn (attackerArray [i]);
			}
		}
	}

	bool IsTimeToSpawn (GameObject gameObject, int arrayPos)
	{
		Attacker attacker = gameObject.GetComponent <Attacker> ();
		
		if (Time.timeSinceLevelLoad >= 160) {
			boss = true;
		}
		if (Time.timeSinceLevelLoad >= 300) {
			hardMode = true;
		}


		float spawnTime = attacker.timeBetweenSpawn + randomiser;

		if (arrayPos == 1 && !boss) {
			return false;
		}
		if (arrayPos == 2 && Time.timeSinceLevelLoad <= 90) {
			return false;
		}

		if (timerArray [arrayPos] >= spawnTime) {
			timerArray [arrayPos] = 0f;
			capSpawn = Mathf.RoundToInt (UnityEngine.Random.Range (0.5f, 3.5f));
			randomiser = UnityEngine.Random.Range (0.3f, 4.8f);
			if (capSpawn == 1) {

				return true;
			} else {

				return false;
			}

		} else {
			timerArray [arrayPos] += Time.deltaTime;
			return false;
		}


		
	}

	//	bool IsTimeToSpawn (GameObject gameObject)
	//	{
	//		Attacker attacker = gameObject.GetComponent <Attacker> ();
	//		float spawnPerSecond = 1 / attacker.timeBetweenSpawn;
	//
	//		if (Time.deltaTime >= attacker.timeBetweenSpawn) {
	//			Debug.LogWarning ("Spawning rate capped by frame rate");
	//		}
	//
	//		float threshold = spawnPerSecond * Time.deltaTime / 5;
	//		if (UnityEngine.Random.value < threshold) {
	//			return true;
	//		} else {
	//			return false;
	//		}
	//
	//	}


	void Spawn (GameObject gameObject)
	{
		GameObject myAttacker = Instantiate (gameObject) as GameObject;
		// spawn to the specific line -> get its transform
		myAttacker.transform.parent = this.transform;
		myAttacker.transform.position = this.transform.position;
	}
}
