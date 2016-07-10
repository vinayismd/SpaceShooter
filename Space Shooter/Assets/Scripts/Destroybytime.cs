using UnityEngine;
using System.Collections;

public class Destroybytime : MonoBehaviour {

	public float lifetime;
	void Start ()
	{
		Destroy (gameObject , lifetime );
	}
}
