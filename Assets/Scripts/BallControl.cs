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
			print (paddleToBallVector.y);
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
}
