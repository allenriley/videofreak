using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{

	public int deaths;

	public KeyCode b1;
	public KeyCode b2;
	public KeyCode b3;
	public KeyCode b4;

	public GameObject p1;
	public GameObject p2;
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float delayTime;

	public Camera cam;


	void Start ()
	{
		StartCoroutine (SpawnWaves ());
		Instantiate (p1, new Vector3 (-4, 0, 0), Quaternion.identity);
		Instantiate(p2, new Vector3 (4, 0, 0), Quaternion.identity);
		delayTime = 0;

	}

	void Update() {

		delayTime += Time.deltaTime;


		if (delayTime >= 30) {
			delayTime = 0;
			SceneManager.LoadScene ("title");
		}

		if (Input.anyKey) {
			delayTime = 0;
		}

		if (Input.GetKey (b1)) {
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount = 1;
		} else {
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().blurAmount = 0;
		}

		if (Input.GetKey (b2)) {
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Vortex>().angle = 50;
		} else {
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Vortex>().angle = 0;
		}

		if (Input.GetKey (b3)) {
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.EdgeDetection>().edgesOnly = 100;
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.EdgeDetection>().edgeExp = .001f;

		} else {
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.EdgeDetection>().edgesOnly = 0;
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.EdgeDetection>().edgeExp = 1;

		}


			


		//Debug.Log ("hi");
		string buttonName = "q";
		if (Input.GetKeyDown (buttonName)) {
			Debug.Log ("RESET");
			SceneManager.LoadScene ("space2");
		}
	}

	void PlayerDeath(){

		deaths += 1;
	
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

}	