using UnityEngine;
using System.Collections;

[System.Serializable] 
public class Boundary
{
	public float xMin,xMax,zMin,zMax;
}


public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	public Vector3 movement;
	public GameObject shot;
	public Transform shotspon;
	public float fireRate;
	
	private float nextFire;

	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotspon.position, shotspon.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate()
	{
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			float movehor = Input.GetAxis ("Horizontal");
			float movever = Input.GetAxis ("Vertical");
			 movement  = new Vector3 (movehor, 0.0f, movever);
		} else {
			float movehor = Input.acceleration.x;
			float movever = Input.acceleration.y;
			 movement  = new Vector3 (movehor, 0.0f, movever);
		}

		GetComponent<Rigidbody>().velocity = movement * speed;

	    GetComponent<Rigidbody> ().position = new Vector3
			(Mathf.Clamp (GetComponent<Rigidbody>().position.x,boundary.xMin,boundary.xMax),
			 0.0f,
			 Mathf.Clamp (GetComponent<Rigidbody>().position.z ,boundary.zMin , boundary.zMax ));

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0, 0, GetComponent<Rigidbody> ().position.x * -tilt);
	}
}
 