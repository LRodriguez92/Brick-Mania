using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] bricks;
	public static int brickCount = 0;
	public AudioClip crack;
	public GameObject smoke;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;

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
		timesHit++;
		AudioSource.PlayClipAtPoint(crack, this.transform.position, .4f);
		handleHits();
	}
	
	// Handles the brick count and the destruction of the bricks
	void handleHits () {
		int maxHits = bricks.Length + 1;
		
		if (timesHit == maxHits) {
			brickCount--;
			puffSmoke();
			Destroy(gameObject);
			Debug.Log (brickCount);
			
			if (brickCount <= 0) {
				Debug.Log ("No more bricks");
				levelManager.LoadNextLevel();
			}
		} else {
			BrickDamage();
		}
	}
	
	void puffSmoke () {
		GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	// Changes to damaged brick sprite after every hit
	void BrickDamage () {
		int hitIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer>().sprite = bricks[hitIndex];
	}
}
