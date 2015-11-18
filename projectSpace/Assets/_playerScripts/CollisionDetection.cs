using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {
	
	// Use this for initialization
	GameObject go;
	
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{				

			GameObject go = col.gameObject;
			PlayerMove script = go.GetComponent<PlayerMove>();
			script.Death();	
			
		}
		
	}
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
