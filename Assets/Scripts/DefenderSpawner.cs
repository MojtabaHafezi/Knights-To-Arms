using UnityEngine;
using System.Collections;
using System;
using System.Security.Cryptography;

public class DefenderSpawner : MonoBehaviour
{
	public Camera myCamera;
	private GameObject defenderParent;
	private CastleManager castleManager;
	public GameObject castleScreen;
	private float timer;
	// Use this for initialization
	void Start ()
	{
		defenderParent = GameObject.Find ("Defenders");
		castleManager = GameObject.FindObjectOfType <CastleManager> ();
		if (defenderParent == null) {
			defenderParent = new GameObject ("Defenders");
		}
		timer = 0;
	}

	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
	}

	void OnMouseDown ()
	{
		if (!castleScreen.activeInHierarchy && Button.selectedDefender != null) {
			int goldCost = Button.selectedDefender.GetComponent <Defender> ().goldCost;
			if (timer >= 1) {
				if (castleManager.UseGold (goldCost) == CastleManager.Status.SUCCESS) {
					GameObject newDefender = Instantiate (Button.selectedDefender, SnapToGrid (WorldPointMouseClick ()), Quaternion.identity) as GameObject;
					newDefender.transform.parent = defenderParent.transform;
					timer = 0;
				}
			}
		}
	}

	Vector2 WorldPointMouseClick ()
	{
		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (x, y, distanceFromCamera);
		Vector2 worldPoint = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPoint;
	}

	Vector2 SnapToGrid (Vector2 rawWorldPosition)
	{
		float newX = Mathf.RoundToInt (rawWorldPosition.x);
		float newY = Mathf.RoundToInt (rawWorldPosition.y);
		return new Vector2 (newX, newY);
	}
}
