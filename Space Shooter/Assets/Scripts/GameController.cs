using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazards;
	public Vector3 spawnValues;
	public int hazardcount;
	public float startwait;
	public float spawnwait;
	public float wavewait;

	public  Text scoretext;
	public Text restarttext;
	public Text gameovertext;

	private int score;
	private bool gameover;
	private bool restart;

	void Start()
	{

		gameover = false;
		restart = false;
		gameovertext.text = "";
		restarttext.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine(Spawnwaves());
	}

	void Update ()
	{
		if (restart)
		{
			if ( Input.touchCount >= 2)
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}


	IEnumerator Spawnwaves()
	{
		yield return new WaitForSeconds (startwait);
		while(true)
		{
		for (int i =0; i < hazardcount;i++) {
			Vector3 spawnposition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnrotaion = Quaternion.identity;
			Instantiate (hazards, spawnposition, spawnrotaion);
			yield return new WaitForSeconds (spawnwait);
	
		     }
			yield return new WaitForSeconds (wavewait);
			if (gameover)
			{
				restarttext.text = "Tap With 2 Fingers";
				restart = true;
				break;
			}

		  }
		}

	public void AddScore(int newscorevalue)
	{
		score += newscorevalue;
		UpdateScore ();

	}


	void UpdateScore ()
	{
		scoretext.text = "Score :" + score;
	}

	public void GameOver ()
	{
		gameovertext.text = "Game Over!";
		gameover = true;
	}
}
