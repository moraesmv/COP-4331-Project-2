using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour
{

	public float moveSpeed = 7f;
	public float jumpForce = 7f;
	bool facingRight = true;
	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
    public LayerMask Stairs;

	Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();

	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);

		float move = Input.GetAxis ("Horizontal");

		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			anim.SetBool ("Ground", false);
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
			
		}
		

		GetComponent<Rigidbody2D>().velocity = new Vector2(move * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        //if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    if()
        //}
		
		anim.SetFloat ("Speed", Mathf.Abs(move));
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

	}

	// Update is called once per frame
	void Update ()
	{
	


	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
