using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {
	public float startScale;
	public float growthRate;
	public float growthMax;
	[System.NonSerialized] // makes sphereTrigger non-editable
	public float sphereTrigger = 100;
	public float scoreStep;

	public void SphereOn () {
		transform.localScale = new Vector3 (startScale, startScale, 1);
		gameObject.SetActive (true);
		sphereTrigger += scoreStep;

	}
		

	// Update is called once per frame
	void Update () {

		transform.localScale += new Vector3 (growthRate, growthRate, 0) * Time.deltaTime;
		if (transform.localScale.x > growthMax) {
			gameObject.SetActive (false);
		}

			

	}
}
