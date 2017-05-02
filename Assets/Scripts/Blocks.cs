using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour {
	
	//public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		isBreakable =(this.tag == "Breakable"); 
		//Keeping track of breakable bricks
		if(isBreakable){
			breakableCount++;
			//print (breakableCount);
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D col){
		//AudioSource.PlayClipAtPoint(crack, transform.position);
		if(isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		//SimulateWin(); Test Flow
		if(timesHit >= maxHits){
			breakableCount--;
			//print (breakableCount);
			levelManager.BrickDestoryed();// Sends message to the level manager script
			Destroy(gameObject);
		}else{
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	
	//TODO Remove this method once we can win!
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
