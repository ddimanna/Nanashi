﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	public Text collection;

	public int numberCollected;
	public GameObject winPanel;
	public GameObject findMyShrooms;
	//public GameObject player;
	//public Component playerthings;
	public PlayerController playerCont;

	// Use this for initialization
	void Start () {
		numberCollected = 0;
		winPanel.SetActive(false);
		//findMyShrooms.SetActive(false);
		//player = GetComponent<PlayerController>();
		//playerthings = GetComponent<PlayerController>();
	
	}
	
	// Update is called once per frame
	void Update () {


		findMyShrooms.SetActive(false);
		collection.text = numberCollected + " / 10"; 

		if(numberCollected >= 10){
			//playerthings.setActive = false;
			playerCont.maxSpeed = 0;
			winPanel.SetActive(true);



		}

	
	}
	public void PlayOnClick(){

		SceneManager.LoadScene(1);

	}

	public void ExitOnClick(){

		SceneManager.LoadScene(0);
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "TurnOnWordBubble"){

			findMyShrooms.SetActive(true);
		}

	}


}
