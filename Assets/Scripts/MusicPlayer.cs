using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	//Variables
	//Diagram on Lecture 68 explains the script calls
	static MusicPlayer instance = null;
	
	void Awake (){ //All awakes will be called first arcoss all scripts in the level
		if (instance != null){
			Destroy (gameObject);
			//Print statement is for logging purposes
			print ("Music player exists destorying self");
		}else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
