using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

	public float health;
	private Animator animator;
	private Attacker attacker;
	public GameObject special;
	private bool hard;
	// Use this for initialization
	void Start ()
	{
		animator = GetComponent <Animator> ();
		attacker = GetComponent <Attacker> ();
		hard = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hard && Time.timeSinceLevelLoad >= 300) {
			hard = true;
			DoubleHealth ();
		}
	}

	public void DoubleHealth ()
	{
		if (gameObject.GetComponent <Attacker> ()) {
			float newHealth = this.health * 2;
			this.health = newHealth;
		}
			
	}

	public void DealDamage (float damage)
	{
	
		health -= damage;
		if (attacker && health <= 0) {
			Instantiate (special, transform.position, Quaternion.identity);
			Invoke ("DestroyGameObject", 0.1f);
			return;
		}
		if (health <= 0) {
			animator.SetBool ("Death", true);
			Instantiate (special, transform.position, Quaternion.identity);
			//Activate Death animation later and call the destroy method by event
		}

	}

	public void DestroyGameObject ()
	{
		Destroy (gameObject);
	}


}
