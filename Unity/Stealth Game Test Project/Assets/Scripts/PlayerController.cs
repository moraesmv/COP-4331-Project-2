using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Controller2D))]
public class PlayerController : MonoBehaviour 
{

	public float maxSpeed = 10;
	bool facingRight = true;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 400f;
	public int score = 0;
	private bool dead = false; 

	public bool levelComplete = false;
	
	Controller2D controller;


	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
		controller = GetComponent<Controller2D> ();
	}
	
	void FixedUpdate()
	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);


		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));
		
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		score = controller.score;
	}

	void Update()
	{
		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			anim.SetBool ("Ground", false);
			GetComponent<Rigidbody2D> ().AddForce(new Vector2(0,jumpForce));
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}