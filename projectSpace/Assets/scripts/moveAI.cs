using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class moveAI : MonoBehaviour
{
    //-- variables related to whole game mode
    GameMode gameModeScript;

    //++



    GameObject go;
    bool levelChanged; // mode after changing level. Search new path.
    bool gameModePause;

    public int health;
    public int armor;

    public int currentLevel;
    public int currentMode; //  0 - just go to the target. 1 - pursuit the player. 2 -attack player through another level
    // 4 - shoot to player but not pursuit

    int speedMode;   // acceleration/nonacceleration
    float speed;       // current speed
    float maxRotSpeed;
    float rotSpeed;

    // service variables
    float minTime;
    int indexTo; //  index of target point
    int range; // radius around point. If NPC inside that radius, then point was reached.

    CharacterController cotrollerOpt;
    Transform transformOpt;
    Transform player;
    Dictionary<int, Vector3> waypoint; // dictionary 

    Vector3 moveDr;


    // Use this for initialization
    void Start()
    {
        gameModePause = false;
        indexTo = 0;
        range = 25;
        health = 100;
        speed = 30f;       // current speed

        maxRotSpeed = 200f;
        minTime = 0.1f;
        rotSpeed = 0f;

        cotrollerOpt = GetComponent<CharacterController>(); // for optimisation
        transformOpt = GetComponent<Transform>(); // for optimisation

        //player = GameObject.Find("player").GetComponent<Transform>();
        creatingPaths pth = GameObject.Find("ManagerScripts").GetComponent<creatingPaths>();
        waypoint = pth.path1;  // recieving an array of points in curren level.

        //--game mode
        gameModeScript = GameObject.Find("ManagerScripts").GetComponent<GameMode>();


    }

    // Update is called once per frame
    void Update()
    {
        // -- dying
        if (health <= 0)
        {
            /**while(animation.isPlaying) // TODO: animation of death
        {
            animation.Play("die");
            return;
        }	*/
            Destroy(gameObject);
        }
        if (!gameModeScript.gameModePause && !gameModeScript.gameModeGameOver)
        {

            //-- moving

            if ((transformOpt.position - waypoint[indexTo]).sqrMagnitude > range)
            {
                Move(waypoint[indexTo]);
            }
            else nextIndex();
        }
        else
        {
            return;
        }


    }

    public void Move(Vector3 target)//++works
    {
        moveDr = transformOpt.forward;
        moveDr.y = 0;
        moveDr *= speed;
        cotrollerOpt.Move(moveDr * Time.deltaTime);

        Vector3 relPos = target - transformOpt.position;
        var newRotation = Quaternion.LookRotation(relPos).eulerAngles;
        var angles = transformOpt.rotation.eulerAngles;
        transformOpt.rotation = Quaternion.Euler(angles.x,
            Mathf.SmoothDampAngle(angles.y, newRotation.y, ref rotSpeed, minTime, maxRotSpeed),
            angles.z);
    }


    public void nextIndex()//++works
    {
        if (++indexTo == waypoint.Count)
        {	// we reached the final target.
            Destroy(gameObject);
        };
    }

    public void getHit(int damage)
    {
        health -= damage;
    }


}
