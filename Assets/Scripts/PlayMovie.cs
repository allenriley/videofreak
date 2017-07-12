using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayMovie : MonoBehaviour {

	public KeyCode fire;



	// Use this for initialization

	void Start () {
	
		Renderer r = GetComponent<Renderer>();

		MovieTexture movie = (MovieTexture)r.material.mainTexture;

		movie.Play ();

		movie.loop = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (fire)) {

			SceneManager.LoadScene ("space2");


		}
	}
}



