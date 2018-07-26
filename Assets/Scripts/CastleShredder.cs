using UnityEngine;
using System.Collections;

public class CastleShredder : MonoBehaviour
{
	private CastleManager castleManager;
	// Use this for initialization
	void Start ()
	{
		castleManager = GameObject.FindObjectOfType <CastleManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		Attacker attacker = collider.gameObject.GetComponent <Attacker> ();
		castleManager.ReduceCastleHealth (attacker.damage);
		Destroy (collider.gameObject);
	}
}
