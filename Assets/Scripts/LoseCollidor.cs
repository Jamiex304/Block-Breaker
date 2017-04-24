using UnityEngine;
using System.Collections;

public class LoseCollidor : MonoBehaviour {

	private LevelManager levelManager;
	
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		}

	void OnTriggerEnter2D (Collider2D collider){
		print ("Trigger");
		levelManager.LoadLevel("Win");
		
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		print ("Collision");
	}
}
