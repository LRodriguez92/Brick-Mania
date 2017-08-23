using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {


	// Use this for initialization
	void Start () {
		this.transform.position = new Vector2 (8f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		PaddleControl();
	}
	
	// The controls for the paddle
	void PaddleControl () {
		float mousePos = (Input.mousePosition.x / Screen.width * 16);
		Vector2 paddle = new Vector2 (mousePos, 1f);
		paddle.x = Mathf.Clamp (mousePos, 1f, 15f);
		this.transform.position = paddle;
	}
}
