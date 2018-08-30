using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScreen : MonoBehaviour {

	private bool flipOn;
	public KeyCode b4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (b4)) {
		//	transform.Rotate (new Vector3(0, 90, 0));
		//	transform.eulerAngles = new Vector3(90, 90, 0);
			transform.eulerAngles = transform.eulerAngles + new Vector3(0, 90, 0);
		}
		else {
			transform.eulerAngles = new Vector3 (90, 0, 0);
	}
		

	}
}
