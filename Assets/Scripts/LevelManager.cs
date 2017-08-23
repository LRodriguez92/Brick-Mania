using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


	public void LoadLevel (string name) {
		Application.LoadLevel(name);
		Debug.Log ("Loading " + name);
	}
	
	public void ApplicationQuit () {
		Application.Quit();
		Debug.Log ("Quitting Application");
	}
	
	public void LoadNextLevel () {
		Application.LoadLevel(Application.loadedLevel + 1);
	} 
	
}
