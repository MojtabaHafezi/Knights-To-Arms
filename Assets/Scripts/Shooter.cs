using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

	public GameObject Projectile, Gun;
	private GameObject ProjectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start ()
	{
		animator = GameObject.FindObjectOfType<Animator> ();

		ProjectileParent = GameObject.Find ("Projectiles");
		if (ProjectileParent == null) {
			ProjectileParent = new GameObject ("Projectiles");
		}

		SetMyLaneSpawner ();
	}

	public bool AttackerIsAhead ()
	{
		//No Attackers available on the lane
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		//check if there is an attacker ahead on the lane
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > this.transform.position.x) {
				return true;
			}	
		}
		//If the attackers are behind the current defender -> stop attacking
		return false;
	}

	void Update ()
	{
		if (AttackerIsAhead ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	//Look at all the spawners and find the one with the same y position as the current shooter
	void SetMyLaneSpawner ()
	{
		Spawner[] spawnerArray = GameObject.FindObjectsOfType <Spawner> ();
		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == this.transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.Log ("Can't find a spawner in any of the lanes");
	}


	// spawn the projectiles in front of the sprite
	private void Fire ()
	{
		GameObject newProjectile = Instantiate (Projectile) as GameObject;
		newProjectile.transform.parent = ProjectileParent.transform;
		newProjectile.transform.position = Gun.transform.position;

	}

}
