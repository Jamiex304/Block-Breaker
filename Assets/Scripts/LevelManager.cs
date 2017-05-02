using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Level Manager script is called within the GameObject in a level called Level Manager (Level Manager object is a empty GameObject)

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string levelName){
		Debug.Log("Level Load Requested for: " + levelName);
		Blocks.breakableCount = 0;
		Application.LoadLevel(levelName); //Loads a level
	}
	
	public void QuitRequest(){
		Debug.Log("Quit Requested for Game");
		Application.Quit(); //Works for console, PC and final build
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
		Blocks.breakableCount = 0;
	}
	
	//If Last Brick is destoryed load next level
	public void BrickDestoryed(){
		if(Blocks.breakableCount <= 0){
			LoadNextLevel();
		}
	}
	
}
