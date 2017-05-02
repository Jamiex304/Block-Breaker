using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {
	private Paddle paddle;
	
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
			//Debug Test
			//print (paddleToBallVector.y);
			//audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		//Set the inital Ball Position	
		if(!hasStarted){
			this.transform.position = paddle.transform.position + paddleToBallVector;
			//Response to mouseclick
			if (Input.GetMouseButtonDown(0)){
				//Debug Test
				print ("Mouse Clicked");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
		
	}
	
	void OnCollisionEnter2D (Collision2D collision){
	
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		
		if(hasStarted){
			audio.Play();
			rigidbody2D.velocity += tweak;
		}
	}
}
