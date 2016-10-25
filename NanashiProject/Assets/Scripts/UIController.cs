using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	public Text collection;

	public int numberCollected;
	public GameObject winPanel;
	//public GameObject player;
	//public Component playerthings;

	// Use this for initialization
	void Start () {
		numberCollected = 0;
		winPanel.SetActive(false);
		//player = GetComponent<PlayerController>();
		//playerthings = GetComponent<PlayerController>();
	
	}
	
	// Update is called once per frame
	void Update () {


		collection.text = numberCollected + " / 10"; 

		if(numberCollected >= 10){
			//playerthings.setActive = false;
			winPanel.SetActive(true);



		}

	
	}
	public void PlayOnClick(){

		SceneManager.LoadScene(1);

	}

	public void ExitOnClick(){

		SceneManager.LoadScene(0);
	}


}
