using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	Animator anim;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float groundRaduis = 0.2f;

	public float maxSpeed = 10;
	public float jumpForce = 200;
	public bool grounded = false;
	public bool doubleJump = false;
	bool facingRight;
	bool dashing;

	public bool doubleJumpPickup;
	public bool dashPickup;
	public bool wallClimbPickup;

	Rigidbody2D rigi;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rigi = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if(grounded && Input.GetButton("Jump")){
			//add double jump
			//add dash coroutines
			// add wallclimb

			//zero out y velocity first using temo
			rigi.AddForce(new Vector2(0, jumpForce));
		}
	
	}

	void FixedUpdate(){

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRaduis, whatIsGround);
		//add wallclimb
		//anim.SetBool("Ground", grounded);

		float move = Input.GetAxis("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs(move));


		rigi.velocity = new Vector2(move * maxSpeed, rigi.velocity.y);


		if(move > 0 && facingRight){
			Flip();
		}
		else if(move < 0 && !facingRight){
			Flip();
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 characterScale = transform.localScale;
		characterScale.x *= -1;
		transform.localScale = characterScale;

	}
}
