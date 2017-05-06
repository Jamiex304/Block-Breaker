using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour {
	
	//public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
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
			PuffSmoke();
			Destroy(gameObject);
		}else{
			LoadSprites();
		}
	}
	
	//ParticleSystem on Blocks
	void PuffSmoke (){
		//Smoke Puff at Block Location
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		//Matching Smoke Puff color to the brick color
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else{
			Debug.LogError ("Brick Sprite Missing");
		}
	}
	
	
	//TODO Remove this method once we can win!
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
