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

	private float groundRadius = 0.2f;

	private float wallRadius = 0.2f;

	public LayerMask whatIsGround;

	public LayerMask whatIsWall;

	private Vector2 temp;
	private Vector2 horizontalTemp;

	private int jumpCount;

	public bool doubleJumpPickup;

	public bool dashPickup;

	public bool wallClimbPickup;

	private bool canDash = true;

	private float dashCoolDown = 0.05f;

	private Animator anim;

	private void Start()
	{
		rigi = GetComponent<Rigidbody2D>();
		temp.y = rigi.velocity.y * 0f;
		horizontalTemp.x = rigi.velocity.x * 0f;
		anim = GetComponent<Animator>();
		doubleJumpPickup = false;
		dashPickup = false;
		wallClimbPickup = false;
	}

	private void FixedUpdate()
	{
		float move = Input.GetAxis("Horizontal");

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		wall = Physics2D.OverlapCircle(wallCheck.position, wallRadius, whatIsWall);

		anim.SetBool("Ground", grounded);
		//anim.SetFloat("vSpeed", rigi.velocity.y);
		anim.SetFloat("Speed", Mathf.Abs(move));

		if (!dashing)
		{
			rigi.velocity = new Vector2( move * maxSpeed, rigi.velocity.y);
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
//		if (Input.GetButtonDown("Select"))
//		{
//			SceneManager.LoadScene(1);
//		}
//
//		if (Input.GetButtonDown("Start"))
//		{
//			SceneManager.LoadScene(0);
//		}



		if (!grounded && canDash && facingRight && Input.GetButtonDown("Dash"))
		{
			if (dashPickup)
			{
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
			}
			else if (doubleJumpPickup && doubleJump)
			{
				doubleJump = false;
				rigi.velocity = temp;
				rigi.AddForce(new Vector2(0f, jumpForce));
			}
		}


		if (wall && Input.GetAxis("Grab") > 0f)
		{
			if (wallClimbPickup)
			{
				rigi.velocity = rigi.velocity * 0f;
				wallClimb();
			}
		}
		else if ((!wall || Input.GetAxis("Grab") <= 0f) && isClimbing)
		{
			rigi.gravityScale = 1f;
			isClimbing = false;
		}
	}


	private void Flip()
	{
		facingRight = !facingRight;
		Vector3 localScale = transform.localScale;
		localScale.x *= -1f;
		transform.localScale = localScale;
	}



//	public IEnumerator rightDash(float dashDuration)
//	{
//		PlayerController.<rightDash>c__Iterator0 <rightDash>c__Iterator = new PlayerController.<rightDash>c__Iterator0();
//		<rightDash>c__Iterator.dashDuration = dashDuration;
//		<rightDash>c__Iterator.<$>dashDuration = dashDuration;
//		<rightDash>c__Iterator.<>f__this = this;
//		return <rightDash>c__Iterator;
//	}
//
//
//	public IEnumerator leftDash(float dashDuration)
//	{
//		PlayerController.<leftDash>c__Iterator1 <leftDash>c__Iterator = new PlayerController.<leftDash>c__Iterator1();
//		<leftDash>c__Iterator.dashDuration = dashDuration;
//		<leftDash>c__Iterator.<$>dashDuration = dashDuration;
//		<leftDash>c__Iterator.<>f__this = this;
//		return <leftDash>c__Iterator;
//	}
	IEnumerator rightDash(float dashDuration){
		dashing = true;

		rigi.velocity = horizontalTemp;
		rigi.AddForce (new Vector2(dashForce, 0f), ForceMode2D.Impulse);

		yield return new WaitForSeconds(dashDuration);

		dashing = false;

	}

	IEnumerator leftDash(float dashDuration){
		dashing = true;

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

			transform.Translate(0f, 4f * Time.deltaTime, 0f);
		}
		else if (Input.GetAxis("Vertical") > 0f)
		{
			rigi.gravityScale = 0f;
			transform.Translate(0f, -4f * Time.deltaTime, 0f);
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
		}
		if (col.gameObject.tag == "WallClimbPickup")
		{
			wallClimbPickup = true;
		}
		if (col.gameObject.tag == "DoubleJumpPickup")
		{
			doubleJumpPickup = true;
		}
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "MovingPlatform")
		{
			Debug.Log("youre on a moving platform");
		}
	}
}