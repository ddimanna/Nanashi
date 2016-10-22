using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	public float speed = 2f;

	public float leftBound;

	public float rightBound;

	public float moveDirection = 1f;

	public float velocityKindOf;

	private Vector3 moveAmount;


	private void Update()
	{
		moveAmount.x = moveDirection * speed * Time.deltaTime;
		if (moveDirection > 0f && transform.position.x > rightBound)
		{
			moveDirection = -1f;
		}
		else if (moveDirection < 0f && transform.position.x < leftBound)
		{
			moveDirection = 1f;
		}
		transform.Translate(moveAmount);
	}
}
