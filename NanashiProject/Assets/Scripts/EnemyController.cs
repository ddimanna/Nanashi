using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

//	public float speed = 2f;
//
//	public float leftBound;
//
//	public float rightBound;
//
//	public float moveDirection = 1f;
//
//	public float velocityKindOf;
//
//	private Vector3 moveAmount;
//
//	public bool facingRight;
//
//
//	void Start(){
//		facingRight = true;
//
//	}
//
//
//	private void Update()
//	{
//		moveAmount.x = moveDirection * speed * Time.deltaTime;
//
//		if (moveDirection > 0f && transform.position.x > rightBound)
//		{
//			moveDirection = -1f;
//
//			if(!facingRight){
//
//				this.Flip();
//			}
//		}
//		else if (moveDirection < 0f && transform.position.x < leftBound)
//		{
//			moveDirection = 1f;
//
//			if(facingRight){
//
//				this.Flip();
//			}
//		}
//		transform.Translate(moveAmount);
//	}
//
//	private void Flip()
//	{
//		facingRight = !facingRight;
//		Vector3 localScale = transform.localScale;
//		localScale.x *= -1f;
//		transform.localScale = localScale;
//	}



//	public float walkSpeed = 2.0f;
//	public float wallLeft = 0.0f;
//	public float wallRight = 5.0f;
//	float walkingDirection = 1.0f;
//	Vector3 walkAmount;
//
//
//	void Update () {
//		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
//
//		if (walkingDirection > 0.0f && transform.position.x >= wallRight)
//		{
//			walkingDirection = -1.0f;
//
//			//Flip();
//
//
//
//		}else if (walkingDirection < 0.0f && transform.position.x <= wallLeft){
//			
//			walkingDirection = 1.0f;
//
//		}
//		transform.Translate(walkAmount);
//	}
//
//	public void Flip(){
//
//		//facingRight = !facingRight;
//		Vector3 localScale = transform.localScale;
//		localScale.x *= -1f;
//		transform.localScale = localScale;
//			
//	}


	public float walkSpeed = 2.0f;
	public float wallLeft = 0.0f;
	public float wallRight = 5.0f;
	float walkingDirection = 1.0f;
	Vector3 walkAmount;
	// Update is called once per frame
	void Update () {
		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		if (walkingDirection > 0.0f && transform.position.x >= wallRight){
			walkingDirection = -1.0f;

//			if(transform.position == wallLeft){
//
//
//			}
		}
		else if (walkingDirection < 0.0f && transform.position.x <= wallLeft){
			walkingDirection = 1.0f;
		}
		transform.Translate(walkAmount);
	}

	//	public void Flip(){
	//
	//		//facingRight = !facingRight;
	//		Vector3 localScale = transform.localScale;
	//		localScale.x *= -1f;
	//		transform.localScale = localScale;
	//			
	//	}


}
