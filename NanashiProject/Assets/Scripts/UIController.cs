using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	public Text collection;
	public Text PickupNotification;

	public int numberCollected;
	public GameObject winPanel;
	//public GameObject findMyShrooms;
	//public GameObject player;
	//public Component playerthings;
	public PlayerController playerCont;

	//public GameObject jumpNotification;

	public GameObject shroomDudeCollider;
	public GameObject lostMyShrooms;
	public GameObject youFoundMyShrooms;
	public GameObject returnToShroomGuy;



	// Use this for initialization
	void Start () {
		numberCollected = 0;
		winPanel.SetActive(false);
		shroomDudeCollider.SetActive (true);

		lostMyShrooms.SetActive(true);
		youFoundMyShrooms.SetActive(false);

		returnToShroomGuy.SetActive(false);
		//jumpNotification.SetActive (false);

		//findMyShrooms.SetActive(false);
		//player = GetComponent<PlayerController>();
		//playerthings = GetComponent<PlayerController>();
	
	}
	
	// Update is called once per frame
	void Update () {


		//findMyShrooms.SetActive(false);
		collection.text = numberCollected + " / 10"; 

		if(numberCollected >= 10){
			shroomDudeCollider.SetActive (false);
			lostMyShrooms.SetActive(false);
			youFoundMyShrooms.SetActive(true);

			if(returnToShroomGuy != null){

				StartCoroutine(ReturnToShroomGuy());

			}

			//playerthings.setActive = false;
//			playerCont.maxSpeed = 0;
//			winPanel.SetActive(true);

			//deactivate the collider by shroom guy so we can get wall climb

		}



//		if (playerCont.doubleJumpPickup == true) {
//
//			StartCoroutine (JumpNotification());
//
//			//PickupNotification.text = "Double Jump Collected";
//
//
//		}

	
	}

	public IEnumerator ReturnToShroomGuy(){


		//PickupNotification.text = "Double Jump Collected";
		returnToShroomGuy.SetActive(true);

		yield return new WaitForSeconds (4f);

		Destroy(returnToShroomGuy);
	}

	public void PlayOnClick(){

		SceneManager.LoadScene("Intro Video");

	}

	public void ExitOnClick(){

		SceneManager.LoadScene("MainMenu1");
	}

	void OnTriggerEnter2D(Collider2D col){


		if(numberCollected >= 10){

			if(col.gameObject.tag == "Player"){

				SceneManager.LoadScene("End Video");
			}
		}
	}
//	void OnCollisionEnter(Collider col){
//
//
//
//	}


//	public IEnumerator JumpNotification (){
//
//
//		//PickupNotification.text = "Double Jump Collected";
//		jumpNotification.SetActive(true);
//
//		yield return new WaitForSeconds (4f);
//
//		jumpNotification.SetActive (false);
//
//		//PickupNotification.text = "";



	//}
//	public IEnumerator JumpNotification (){
//
//
//		PickupNotification.text = "Double Jump Collected";
//
//		yield return new WaitForSeconds (4f);
//
//		PickupNotification.text = "";
//
//
//
//	}



}
