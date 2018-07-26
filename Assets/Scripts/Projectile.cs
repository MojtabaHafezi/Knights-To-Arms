using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

	public float speed, damage;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		transform.Translate (Vector3.right * speed * Time.deltaTime);

	}

	//only if the projectile hits an attacker: deal some damage
	void OnTriggerEnter2D (Collider2D collider)
	{
		Attacker attacker = collider.gameObject.GetComponent<Attacker> ();
		Health health = collider.gameObject.GetComponent<Health> ();
		if (attacker && health) {
			health.DealDamage (damage);
			//if not piercing skill - destroy on first hit
			Destroy (gameObject);
		}
	}

}
