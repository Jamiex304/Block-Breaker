using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	
	private BallControl ball;
	// Use this for initialization
	void Start(){
		ball = GameObject.FindObjectOfType<BallControl>();
		//print(ball);
	}
	// Update is called once per frame
	void Update () {
		if(autoPlay == false){
			MoveWithMouse();
		}else{
			AutoPlay();
		}
	}
	
	//Automated Play testing function to test out the full level
	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0f, this.transform.position.y , -0.25f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp((ballPos.x), -7.5f, 7.5f);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3 (0f, this.transform.position.y , -0.25f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp((mousePosInBlocks - 7.5f), -7.5f, 7.5f);
		this.transform.position = paddlePos;
	}
}
