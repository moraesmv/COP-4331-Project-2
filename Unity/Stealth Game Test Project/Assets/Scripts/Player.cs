﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Controller2D))]
public class Player : MonoBehaviour 
{
    public float gravity = -9.8f;
    public float moveSpeed = 5;
    public int score = 0;
    Vector3 velocity;

    public bool levelComplete = false;

	Controller2D controller;

	void Start()
	{
        controller = GetComponent<Controller2D> ();
	}

    void Update()
    {

        Vector2 input = new Vector2 ( Input.GetAxisRaw ( "Horizontal" ), Input.GetAxisRaw ( "Vertical" ) );

        velocity.x = input.x * moveSpeed;
        velocity.y += gravity + Time.deltaTime;
        controller.Move ( velocity * Time.deltaTime );
        score = controller.score;
    }

}
