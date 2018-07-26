using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour
{
	//the button needs to pass a prefab for instantiation
	public GameObject defenderPrefab;
	//an array for the buttons to select only 1 at a time
	private Button[] buttonArray;
	//to have access for the selected button
	public static GameObject selectedDefender;

	private Text costText;

	void Start ()
	{
		
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		costText = GetComponentInChildren <Text> ();
		if (!costText) {
			// on error behaviour
		}

		costText.text = defenderPrefab.GetComponent <Defender> ().goldCost.ToString ();
	}

	//when mouse/touch input clicks on it
	void OnMouseDown ()
	{
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent <SpriteRenderer> ().color = Color.black;
		}

		GetComponent <SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
