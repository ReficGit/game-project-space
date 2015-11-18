using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {
	
	GameMode gameModeScript;
	public int health;
	public GUIStyle healthBoxStyle;
	public GUIStyle healthLabelStyle;
	
	// Use this for initialization
	void Start () {
		health = 100;	
		gameModeScript = GameObject.Find("ManagerScripts").GetComponent<GameMode>();
	}
	
	public void collisionDetect(int damage)
	{
		health -= damage;
		health = (health > 0) ? health : 0;
		if (health <= 0)
		{			
			gameModeScript.gameModeGameOver = true;
			gameModeScript.gameModePause = true;
			
			Destroy(gameObject);
		}
	}

	void OnGUI()
	{
		// health bar + text.
		GUI.Box(new Rect(10,10,health*2,20),"", healthBoxStyle);
		GUI.Label(new Rect(210,10, 100, 20),"+"+health+" H P (mother-ship core)",healthLabelStyle);
	}
}
