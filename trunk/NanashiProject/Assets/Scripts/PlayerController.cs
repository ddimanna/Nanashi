using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float maxSpeed = 10f;

	private bool facingRight = true;

	public bool grounded;

	public bool wall;

	public float jumpForce = 700f;

	public float dashForce = 1f;

	public bool doubleJump;

	private bool dashing;

	private bool isClimbing;

	public Rigidbody2D rigi;

	public Transform groundCheck;

	public Transform wallCheck;

	private float groundRadius = 0.4f;

	private float wallRadius = 0.2f;

	public LayerMask whatIsGround;

	public LayerMask whatIsWall;

	private Vector2 temp;
	private Vector2 horizontalTemp;

	private int jumpCount;

	public bool doubleJumpPickup;

	public bool dashPickup;

	public bool wallClimbPickup;

	public bool climbing; //used for animator

	private bool canDash = true;

	//private float dashCoolDown = 0.05f;

	public float slerpSpeed = 2;

	Vector2 upNormalTemp;

	private Animator anim;
	public UIController collectedCount;
	//public GameObject findMyShrooms;
	public GameObject jumpNotification;
	public GameObject dashNotification;
	public GameObject wallClimbNotification;
	//public GameObject ShroomDudeCollider;

	private void Start()
	{
		rigi = GetComponent<Rigidbody2D>();
		temp.y = rigi.velocity.y * 0f;
		horizontalTemp.x = rigi.velocity.x * 0f;
		anim = GetComponent<Animator>();
		doubleJumpPickup = false; //change later
		dashPickup = false; // change later
		wallClimbPickup = false;
		upNormalTemp = transform.up;
		//findMyShrooms.SetActive(false);
		jumpNotification.SetActive(false);
		dashNotification.SetActive(false);
		wallClimbNotification.SetActive(false);
		//ShroomDudeCollider.SetActive (true);

	}

	private void FixedUpdate()
	{
		float move = Input.GetAxis("Horizontal");

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		wall = Physics2D.OverlapCircle(wallCheck.position, wallRadius, whatIsWall);


		RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundRadius);

		if(hit){

			Debug.Log("HIT");
			if(hit.collider.tag == ("Walkable")){

				Debug.Log("SUPERMEGAAWESOMEHIT");


			}
		}

		//transform.up = hit.normal;

//		transform.rotation = Quaternion.Slerp(transform.rotation, 
//			Quaternion.EulerAngles(new Vector3(hit.normal.x, 0, hit.normal.y)), Time.time * slerpSpeed);

		if(transform.up.x > hit.normal.x + slerpSpeed){
			//transform.up.y-= slerpSpeed;
			upNormalTemp = transform.up;
			upNormalTemp = upNormalTemp - new Vector2(slerpSpeed, 0);
			transform.up = upNormalTemp;

		}else if(transform.up.x < hit.normal.x - slerpSpeed){

			upNormalTemp = transform.up;
			upNormalTemp = upNormalTemp + new Vector2(slerpSpeed, 0);
			transform.up = upNormalTemp;
		}


		anim.SetBool("Ground", grounded);
		//anim.SetFloat("vSpeed", rigi.velocity.y);
		anim.SetFloat("Speed", Mathf.Abs(move));


		if (!dashing)
		{
			rigi.velocity = new Vector2(move * maxSpeed, rigi.velocity.y);
			if (move > 0f && !facingRight)
			{
				this.Flip();
			}
			else if (move < 0f && facingRight)
			{
				this.Flip();
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene(0);
		}
//
//		if (Input.GetButtonDown("Start"))
//		{
//			SceneManager.LoadScene(0);
//		}

		anim.SetBool("Jump", false);

		if (!grounded && canDash && facingRight && Input.GetButtonDown("Dash"))
		{
			if (dashPickup)
			{
				Debug.Log("you got the pickup");
				StartCoroutine(rightDash(0.07f));
			}
		}
		else if (!grounded && canDash && !facingRight && Input.GetButtonDown("Dash") && dashPickup)
		{
			StartCoroutine(leftDash(0.07f));
		}


		if (Input.GetButtonDown("Jump"))
		{
			if (grounded)
			{
				rigi.velocity = temp;
				rigi.AddForce(new Vector2(0f, jumpForce));
				doubleJump = true;
				anim.SetBool("Jump", true);
			}
			else if (doubleJumpPickup && doubleJump)
			{
				doubleJump = false;
				rigi.velocity = temp;
				rigi.AddForce(new Vector2(0f, jumpForce));
				anim.SetBool("Jump", true);
			}
		}


		//if (wall && Input.GetAxis("Grab") > 0f)
		if(wall && Input.GetButton("Grab"))
		{
			if (wallClimbPickup)
			{
				rigi.velocity = rigi.velocity * 0f;
				wallClimb();
			}
		}
		//else if ((!wall || Input.GetAxis("Grab") <= 0f) && isClimbing)
		else if(!wall) //|| Input.GetButton("Grab"))
		{
			rigi.gravityScale = 1f;
			isClimbing = false;
			anim.SetBool("Climbing", false);
		}

		//findMyShrooms.SetActive(false);
	}


	private void Flip()
	{
		facingRight = !facingRight;
		Vector3 localScale = transform.localScale;
		localScale.x *= -1f;
		transform.localScale = localScale;
	}


	IEnumerator rightDash(float dashDuration){
		dashing = true;

		Debug.Log("right you're dashing");

		rigi.velocity = horizontalTemp;
		rigi.AddForce (new Vector2(dashForce, 0f), ForceMode2D.Impulse);

		yield return new WaitForSeconds(dashDuration);

		dashing = false;

	}

	IEnumerator leftDash(float dashDuration){
		dashing = true;

		Debug.Log("left you're dashing");
		rigi.velocity = horizontalTemp;
		rigi.AddForce (new Vector2(-dashForce, 0f), ForceMode2D.Impulse);

		yield return new WaitForSeconds(dashDuration);

		dashing = false;



	}
	private void wallClimb()
	{
		grounded = true;
		if (Input.GetAxis("Vertical") < 0f)
		{
			rigi.gravityScale = 0f;

			climbing = true;

			anim.SetBool("Climbing", true);

			transform.Translate(0f, 4f * Time.deltaTime, 0f);
		}
		else if (Input.GetAxis("Vertical") > 0f)
		{
			rigi.gravityScale = 0f;
			transform.Translate(0f, -4f * Time.deltaTime, 0f);

			anim.SetBool("Climbing", true);
		}
		isClimbing = true;
	}



	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Spikey")
		{
			Debug.Log("You Done Died");
			SceneManager.LoadScene(0);
		}
		if (dashing && col.gameObject.tag == "BreakableWall")
		{
			UnityEngine.Object.Destroy(col.gameObject);
		}


	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "DashPickup")
		{
			dashPickup = true;
			//start dash pickup coroutine
			StartCoroutine(DashNotification());
		}
		if (col.gameObject.tag == "WallClimbPickup")
		{
			wallClimbPickup = true;
			//start wall climb coroutine
			StartCoroutine(WallClimbNotification());
		}
		if (col.gameObject.tag == "DoubleJumpPickup")
		{
			doubleJumpPickup = true;
			//start the double jump coroutine
			StartCoroutine(JumpNotification());
		}

		if(col.gameObject.tag == "Shroom"){
			collectedCount.numberCollected++;
		}
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "MovingPlatform")
		{
			Debug.Log("youre on a moving platform");
		}
	}

//	void OnTriggerStay2D(Collider2D col){
//		if(col.gameObject.tag == "TurnOnWordBubble"){
//
//			findMyShrooms.SetActive(true);
//		}else{
//
//			findMyShrooms.SetActive(false);
//		}
//
//	}
	public IEnumerator JumpNotification (){


		//PickupNotification.text = "Double Jump Collected";
		jumpNotification.SetActive(true);

		yield return new WaitForSeconds (4f);

		jumpNotification.SetActive (false);

		//PickupNotification.text = "";
	}

	public IEnumerator DashNotification (){


		//PickupNotification.text = "Double Jump Collected";
		dashNotification.SetActive(true);

		yield return new WaitForSeconds (4f);

		dashNotification.SetActive (false);

		//PickupNotification.text = "";
	}

	public IEnumerator WallClimbNotification (){


		//PickupNotification.text = "Double Jump Collected";
		wallClimbNotification.SetActive(true);

		yield return new WaitForSeconds (4f);

		wallClimbNotification.SetActive (false);

		//PickupNotification.text = "";
	}

}