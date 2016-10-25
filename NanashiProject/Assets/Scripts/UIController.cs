using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text collection;

	public int numberCollected;

	// Use this for initialization
	void Start () {
		numberCollected = 0;
	
	}
	
	// Update is called once per frame
	void Update () {


		collection.text = numberCollected + " / 10"; 

	
	}
}
