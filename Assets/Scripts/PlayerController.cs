using UnityEngine;
using System.Collections;

[System.Serializable]

public class Boundary
{
	public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour 
{

	public string HAxis;
	public string VAxis;
	public KeyCode shoot;
	public KeyCode wild;

	public float deathTime;


	public float speed;
	public Boundary boundary;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;
	private bool isDead;

	void Start(){

		isDead = false;

	}
	void Update() {

		if (isDead&&Time.time>=deathTime+1) {
			if (Input.GetKey (shoot)) {

				gameObject.GetComponent<MeshRenderer> ().enabled = true;
				gameObject.transform.position = new Vector3 (0, 0, 0);
				isDead = false;

			}
		}
				

		if (Input.GetKey (shoot) && Time.time > nextFire&&!isDead) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}

		if (Input.GetKey (wild)) {

			GetComponent<TrailRenderer> ().time = 5;
			GetComponent<PlayerController> ().speed = 10;
		}

		else {
			GetComponent<TrailRenderer> ().time = 0;
			GetComponent<PlayerController> ().speed = 20;


		}


	}	


	void FixedUpdate ()
	{

		if (!isDead) {
			float moveHorizontal = Input.GetAxis (HAxis);
			float moveVertical = Input.GetAxis (VAxis);

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			GetComponent<Rigidbody> ().velocity = movement * speed;
	
			GetComponent<Rigidbody> ().position = new Vector3 (
			
				Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
			);

			GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody> ().velocity.x * -tilt);
		} else {

			GetComponent<Rigidbody> ().velocity = new Vector3(0, 0, 0)*0;


		}
	}

	public void kill(){

		isDead = true;
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		gameObject.GetComponent<Rigidbody> ().velocity = new Vector3(0, 0, 0);
		deathTime = Time.time;
	}

}