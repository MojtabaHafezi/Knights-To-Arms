using UnityEngine;
using System.Collections;
using System.Configuration;

public class Attacker : MonoBehaviour
{

	[Range (0.05f, 2.5f)]
	public float currentSpeed;

	[Tooltip ("Decides the spawning rate")]
	public float timeBetweenSpawn;

	public int damage = 0;
	private Animator anim;
	private Rigidbody2D myRigidbody;
	private GameObject currentTarget;


	void Start ()
	{
		AddComponents ();
		anim = this.GetComponent<Animator> ();
		timeBetweenSpawn += Random.Range (0.5f, 2.5f);
	}
	// Update is called once per frame
	void Update ()
	{
		this.transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			anim.SetBool ("isAttacking", false);
		}
	}

	//basic components being added manually like rigidbody
	void AddComponents ()
	{
		myRigidbody = gameObject.AddComponent<Rigidbody2D> ();
		myRigidbody.isKinematic = true;
	}

	//what happens on trigger enter
	void OnTriggerEnter2D (Collider2D collider)
	{
		//Debug.Log ("collided with" + collider);
		//if the GameObject has a "Defender" component, then the animation will be triggered. 
		GameObject obj = collider.gameObject;
		if (!obj.GetComponent<Defender> ()) {
			return;
		}

		//set the animation to attacking and also decide on target
		anim.SetBool ("isAttacking", true);
		currentTarget = obj;

	}

	//set the speed of the movement within the animationevent
	public void SetSpeed (float speed)
	{
		this.currentSpeed = speed;
	}

	//Used in the animationevent to deal damage
	public void StrikeCurrentTarget (float damage)
	{
		//if there is a target then get its health component
		if (currentTarget) {
			Health health =	currentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage (damage);
			}

		}
	}
}
