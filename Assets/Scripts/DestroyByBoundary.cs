using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{

		if (other.tag == "Enemy") {
			//Debug.Log ("hello");
			Destroy (other.gameObject);

		}
		if (other.tag == "Bolt") {
			//Debug.Log ("hello");
			Destroy (other.gameObject);
	
		}
	}
}