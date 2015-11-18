using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {
	
	//-- game mode
	public bool gameModePause;
	public bool gameTowerPlace;
	public bool gameModeGameOver;
	
	
	//-- interface variables.
	int HomeHealth;
	int score;
	int playerHealth;
		
	//-- GUI styles
	public GUIStyle stlPause;
	public GUIStyle stlGameOver;
	
	//-- link variables to other object and classes
	Home homeLnk;
	
	
	// Use this for initialization
	void Start () {
		gameModePause = false;
		gameTowerPlace = false;
		gameModeGameOver = false;		
	}
	
	
	void OnGUI()
	{
		// PAUSE
		if(gameModePause && !gameModeGameOver)
		{
			GUI.Label(new Rect(Screen.width/2,50, 100, 50),"PAUSE",stlPause);
		}
		// Target destroyed.
		if(gameModeGameOver)
		{
			
			if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-25, 100, 50),"RESTART"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2 + 26, 100, 50),"EXIT"))
			{
				Application.Quit();
			}
			GUI.Label(new Rect(Screen.width/2-50,50, 100, 50),"GAME OVER",stlGameOver);
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			gameModePause =  !gameModePause;
		}
	Debug.Log(gameModePause);
	}
	
}
