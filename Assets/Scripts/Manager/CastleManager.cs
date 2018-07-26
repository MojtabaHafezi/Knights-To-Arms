using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.Networking.NetworkSystem;

[RequireComponent (typeof(Text))]
public class CastleManager : MonoBehaviour
{
	public Text goldDisplay, goldCostText, healthCostText, healthDisplay, timeDisplay;
	private int golds = 100;
	private int goldPerSec = 1;
	private int castleHealth = 100, baseCastleHealth = 100;
	private int goldPerSecCost = 50, healthCost = 50;

	private LevelManager levelManager;
	public Slider slider;

	public enum Status
	{
		SUCCESS,
		FAILURE
	}


	public GameObject castlePanel;
	// Use this for initialization
	void Awake ()
	{
		levelManager = GameObject.FindObjectOfType <LevelManager> ();
		castlePanel.SetActive (false);
		UpdateDisplay ();
	

	}

	void Start ()
	{
		slider.maxValue = castleHealth;
		slider.value = castleHealth;
		InvokeRepeating ("AddGold", 1f, 1.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void AddGold ()
	{
		golds += goldPerSec;
		UpdateDisplay ();
	}

	public Status UseGold (int amount)
	{
		if (golds >= amount) {
			golds -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;

	}

	public void DoubleHealth ()
	{
		if (golds >= healthCost) {
			golds -= healthCost;
			healthCost *= 2;
			baseCastleHealth *= 2;
			castleHealth += (baseCastleHealth / 2);
		}
		UpdateDisplay ();
		ReduceCastleHealth (0);
	}

	public void DoubleGoldIncome ()
	{
		if (golds >= goldPerSecCost) {
			golds -= goldPerSecCost;
			goldPerSec *= 2;
			goldPerSecCost *= 2;

		}
		UpdateDisplay ();
		
	}

	public void ReduceCastleHealth (int damage)
	{
		castleHealth -= damage;
		slider.maxValue = baseCastleHealth;
		slider.value = castleHealth;

		if (castleHealth <= 0) {
			levelManager.LoadLevel ("03 Lose");
		}
	}

	void UpdateDisplay ()
	{
		goldDisplay.text = golds.ToString ();
		healthCostText.text = "Cost " + healthCost.ToString ();
		goldCostText.text = "Cost " + goldPerSecCost.ToString ();
		healthDisplay.text = castleHealth.ToString ();
		timeDisplay.text = (600 - Math.Round (Time.timeSinceLevelLoad)).ToString ();
	}

	void OnMouseDown ()
	{
		castlePanel.SetActive (true);
		Time.timeScale = 0f;
	}

	public void ClosePanel ()
	{
		castlePanel.SetActive (false);
		Time.timeScale = 1;
	}
}
