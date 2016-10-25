using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

public void OnClick()

	{
		SceneManager.LoadScene (1);
	}

	void Update(){

		if(Input.GetButtonDown("Start")){

			SceneManager.LoadScene(1);
		}
	}

}
