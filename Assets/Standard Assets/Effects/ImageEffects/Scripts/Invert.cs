// obsolete

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invert : MonoBehaviour {

	[System.NonSerialized]
	public bool invertOn;

	public KeyCode b3;

	// Use this for initialization
	void Start () {
		invertOn = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (b3)) {

			gameObject.transform.position = new Vector3 (1, 2, 1);
			invertOn = true;
		}

		else {
			gameObject.transform.position = new Vector3 (1, 10, 1);
			invertOn = false;

	}

}

}