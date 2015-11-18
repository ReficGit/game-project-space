using UnityEngine;
using System.Collections;

public class TeleportV2 : MonoBehaviour {
	//Defines the position of each level
	public GameObject level1;
	public GameObject level2;
	public GameObject level3;
	
	//Initialize position
	Vector3 startPosition;
	Vector3 endPosition;
	Vector3 endPosition1;
	Vector3 endPosition2;
	Vector3 endPosition3;
	
	//False or true movement
	bool move_down;
	bool move_up;
	
	public float liftSpeed = 1;
	float weight = 0;
	
	// Use this for initialization
	void Start () {
		move_down = false;
		move_up = false;
		endPosition1 = level1.transform.position;
		endPosition2 = level2.transform.position;
		endPosition3 = level3.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.X)){
				if (move_down){ 
					move_up = false;
					print("Wait. We are going down.");
				}
				
				else {
					check_pos_up ();
					weight = 0;
					move_up = true;
				}
			}
		
		if(Input.GetKeyDown(KeyCode.Z)){
				if (move_up){ 
					move_down = false;
					print("Wait. We are going up.");
				}
				
				else {
					check_pos_down ();
					weight = 0;
					move_down = true;
				}
			}	
		
		if (move_up){
			teleport_up ();	
		}
		if (move_down){
			teleport_down ();	
		}
}	
	
	void check_pos_up (){
		startPosition = transform.position;
		endPosition[0] = startPosition[0];
		endPosition[2] = startPosition[2];
		
		if (startPosition[1] == endPosition1[1]){
				endPosition[1] = 50.5f; //endPosition2[1];
				print("Up! Level 2 t eleport");						
			}
		else if (startPosition[1] == endPosition2[1]){
				endPosition[1] = endPosition3[1];
				print("Up! Level 3 teleport");
			}	
		else endPosition = startPosition;
		}
	
	void check_pos_down () {
		startPosition = transform.position;
		endPosition[0] = startPosition[0];
		endPosition[2] = startPosition[2];
		
		if (startPosition[1] == endPosition3[1]){
				endPosition[1] = endPosition2[1];
				print("Down! Level 2 teleport");						
			}
		else if (startPosition[1] == endPosition2[1]){
				endPosition[1] = endPosition1[1];
				print("Down! Level 3 teleport");
			}	
		else endPosition = startPosition;
		}
	
	void teleport_up(){
				print ("Teleporting");
				weight += Time.deltaTime * liftSpeed;
				transform.position = Vector3.Lerp(startPosition, endPosition ,weight);
		if (transform.position == endPosition){
				move_up = false;
				print("Movement is stopped");
			}
		}	
	
	void teleport_down(){
				print ("Teleporting");
				weight += Time.deltaTime * liftSpeed;
				transform.position = Vector3.Lerp(startPosition, endPosition ,weight);
		if (transform.position == endPosition){
				move_down = false;
				print("Movement is stopped");
			}
		}	
}