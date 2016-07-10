using UnityEngine;
using System.Collections;

public class Destroybycontact : MonoBehaviour {

	public GameObject collision;
	public GameObject playerexplosion;
	private GameController gameController;
	public int scorevalue;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}


	void OnTriggerEnter (Collider other){

		if (other.tag == "Boundary" ) {
			return;
		}
		Instantiate (collision, transform.position, transform.rotation);
		if (other.tag == "Player")
		{
			Instantiate(playerexplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}

		gameController.AddScore (scorevalue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
