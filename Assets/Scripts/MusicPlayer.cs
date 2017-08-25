using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	private static bool musicPlayer = false;

	// Use this for initialization
	void Awake () {
		if (musicPlayer == false) {
			audio.Play();
			Debug.Log ("Music start");
			musicPlayer = true;
			DontDestroyOnLoad(gameObject);
		} else if (musicPlayer) {
			Destroy(gameObject);
			Debug.Log ("Deleted duplicate player");
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
