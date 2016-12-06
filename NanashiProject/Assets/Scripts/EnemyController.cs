using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed = 2f;

	public float leftBound;

	public float rightBound;

	public float moveDirection = 1f;

	public float velocityKindOf;

	private Vector3 moveAmount;

	public bool facingRight;


	void Start(){
		facingRight = true;

	}


	private void Update()
	{
		moveAmount.x = moveDirection * speed * Time.deltaTime;

		if (moveDirection > 0f && transform.position.x > rightBound)
		{
			moveDirection = -1f;

			if(!facingRight){

				this.Flip();
			}
		}
		else if (moveDirection < 0f && transform.position.x < leftBound)
		{
			moveDirection = 1f;

			if(facingRight){

				this.Flip();
			}
		}
		transform.Translate(moveAmount);
	}

	private void Flip()
	{
		facingRight = !facingRight;
		Vector3 localScale = transform.localScale;
		localScale.x *= -1f;
		transform.localScale = localScale;
	}
}
