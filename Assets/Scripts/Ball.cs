﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Vector3 paddleToBallVector;
	private Paddle paddle;
	private bool hasStarted;

	// Use this for initialization
	void Start () {
		paddle = FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
		 
		 	//Launch Ball
			if (Input.GetMouseButtonDown(0)) {
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (3f, 16f);
			}
		}	
	}
	
	void OnCollisionEnter2D (Collision2D coll) {
		Vector2 tweak = new Vector2 (.2f, .2f);
		
		if (hasStarted) {
			rigidbody2D.velocity += tweak;
		}
	}
	
}
