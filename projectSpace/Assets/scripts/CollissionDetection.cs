using UnityEngine;
using System.Collections;
using System;

public class CollissionDetection : MonoBehaviour {
	
	const int hitFromTank = 25;
	const int hitToAnyMob = 101;
	
	void OnTriggerEnter(Collider col) // DOESN'T DETECTS COLLISION!!!
	{
		GameObject go;
		
		Debug.Log ("Collison");
		try
		{
			if(col.gameObject.tag == "Mob")
			{	
				go = col.gameObject;
				moveAI script = go.GetComponent<moveAI>();
				script.getHit(hitToAnyMob);
				
				Home hmScr = gameObject.GetComponent<Home>();
				hmScr.collisionDetect(hitFromTank);
			}
		} catch (Exception e)
		{
			Debug.Log(e);
		}		
	}
}
