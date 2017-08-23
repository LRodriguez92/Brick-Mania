using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] bricks;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;
	private static int brickCount = 0;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		isBreakable = (this.tag == "Breakable");	
		timesHit = 0;
		
		// Keeps track of breakable bricks
		if (isBreakable) {
			brickCount++;
			Debug.Log (brickCount);
		}
	}

	
	void OnCollisionEnter2D (Collision2D coll) {
		int maxHits = bricks.Length + 1;
		timesHit++;
			
		if (timesHit == maxHits) {
			Destroy(gameObject);
			brickCount--;
			Debug.Log (brickCount);
				
			if (brickCount <= 0) {
				Debug.Log ("No more bricks");
				levelManager.LoadNextLevel();
			}
		} else {
			BrickDamage();
		}
	}
	
	// Changes to damaged brick sprite after every hit
	void BrickDamage () {
		int hitIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer>().sprite = bricks[hitIndex];
	}
}
