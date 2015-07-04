using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed = 3f;
	public bool moveRight = false;
	public float moveDelay = 0.5f;

	private int counter = 50;
	private int initialCounter = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (moveRight)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (counter == 0)
		{
			Flip();
			counter = initialCounter;
		}
		counter--;

	}

	void Flip()
	{
		moveRight = !moveRight;
	}
}
