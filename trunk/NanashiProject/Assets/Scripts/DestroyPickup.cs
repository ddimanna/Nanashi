using System;
using UnityEngine;

public class DestroyPickup : MonoBehaviour
{
	
	private void OnTriggerEnter2D(Collider2D col)
	{
		Destroy(gameObject);
	}
}
