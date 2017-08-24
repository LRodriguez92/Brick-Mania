using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay;
	
	private Ball ball; 

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector2 (8f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (autoPlay) {
			AutoPlay();
		} else {
			PaddleControl();		
		}
	}
	
	// The controls for the paddle
	void PaddleControl () {
		float mousePos = (Input.mousePosition.x / Screen.width * 16);
		Vector2 paddle = new Vector2 (mousePos, 1f);
		paddle.x = Mathf.Clamp (mousePos, 1f, 15f);
		this.transform.position = paddle;
	}
	
	// Paddle automatically moves with ball
	void AutoPlay () {
		ball = FindObjectOfType<Ball>();
		float ballPos = ball.transform.position.x;
		Vector2 paddlePos = new Vector2 (ballPos, this.transform.position.y);
		paddlePos.x = Mathf.Clamp(ballPos, 1f, 15f);
		this.transform.position = paddlePos;
	}
	
}
