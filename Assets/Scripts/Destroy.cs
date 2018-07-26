using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Invoke ("DestroyGameObject", 0.6f);
	}

	void DestroyGameObject ()
	{
		Destroy (gameObject);
	}
}
