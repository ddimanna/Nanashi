using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SkipEndCutscene : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine(CutSceneDuration());
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButton("Jump") || Input.GetButton("Start")){


			SceneManager.LoadScene("MainMenu1");
		}

		//duplicate the script
		if(Input.GetKey(KeyCode.Escape)){

			SceneManager.LoadScene("MainMenu1");
		}
	
	}

	public IEnumerator CutSceneDuration(){

		yield return new WaitForSeconds(57);


		SceneManager.LoadScene("MainMenu1");
	}
}
