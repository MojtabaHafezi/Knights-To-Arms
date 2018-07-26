using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D collider)
	{
		Projectile checker = collider.gameObject.GetComponent <Projectile> ();
		if (checker != null) {
			Destroy (collider.gameObject);
		}

	}
}
