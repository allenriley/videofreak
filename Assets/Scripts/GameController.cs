using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{

	public int deaths;
	public int points;
	public KeyCode b1;
	public KeyCode b2;
	public SphereController sphereController;
	public GameObject p1;
	public GameObject p2;
	public GameObject hazard;
	public GameObject dots;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float delayTime;
	public float blurValue;
	public float vortexValue;
	//public float invertA;
	//public float invertB;
	private bool blurOn;
	private bool vortexOn;
	public Camera cam;

	//singleton
	public static GameController instance;

	void Awake(){
		instance = this;	//set our singleton
	}

	void Start ()
	{
		Instantiate (p1, new Vector3 (-4, 0, 0), Quaternion.identity);
		Instantiate(p2, new Vector3 (4, 0, 0), Quaternion.identity);
		delayTime = 0;
		points = 0;
		deaths = 0;
		StartCoroutine (SpawnWaves ());


	}

	void Update() {


		if (Input.anyKey) {
			delayTime = 0;
		}

		delayTime += Time.deltaTime;


		if (delayTime >= 30) {
			delayTime = 0;
			SceneManager.LoadScene ("title");
		}
			
		//Debug.Log ("hi");
		string buttonName = "q";
		if (Input.GetKeyDown (buttonName)) {
			Debug.Log ("RESET");
			SceneManager.LoadScene ("space2");
			Debug.Log (Time.deltaTime);
		}
			
		if (Input.GetKey (b1)) {
			blurOn = true;
		} else {
			blurOn = false;
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur> ().blurAmount = 0;

		}

		if (blurOn == true) {
			StartCoroutine (BlurEffect ());
		}			
		if (Input.GetKey (b2)) {
			vortexOn = true;
		} else {
			vortexOn = false;
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Vortex> ().angle = 0;
		}

		if (vortexOn == true) {
			StartCoroutine (VortexEffect ());
		}
			
	}
		

	public IEnumerator BlurEffect() {

		blurValue = 1f;
		while (blurValue > 0) {
			blurValue -= .7f * (Time.deltaTime*Time.deltaTime);
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur> ().blurAmount = blurValue;
			yield return null;
		}
			
			}

	public IEnumerator VortexEffect() {

		vortexValue = 360;
		while (vortexValue > 0) {
			vortexValue -= 1000f * (Time.deltaTime*Time.deltaTime);
			Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Vortex>().angle = vortexValue;
			yield return null;
		}

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


	public void AddDeaths (int newDeaths){
		deaths += newDeaths;
	}

	public void AddPoints (int newPoints){
		points += newPoints;

		if ( points > sphereController.sphereTrigger ) {
			sphereController.SphereOn();
		}
	}


}	