using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	//Variables
	static MusicPlayer instance = null;
	// Use this for initialization
	void Start () {
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
