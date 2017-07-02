using UnityEngine;
using System.Collections;


public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerexplosion;
	public GameObject GC;

	public void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);

		if (other.tag == "Player") {	
			Instantiate (explosion, other.transform.position, other.transform.rotation);
			other.gameObject.GetComponent<PlayerController> ().kill ();
		}

		//GC = GameObject.Find (GameController);
		//GC.PlayerDeath();
		Destroy(gameObject);

	}
}		


