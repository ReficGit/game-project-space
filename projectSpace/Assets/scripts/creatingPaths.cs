using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class creatingPaths : MonoBehaviour {
	
	public Dictionary<int, Vector3> path3;
	public Dictionary<int, Vector3> path2;
    public Dictionary<int, Vector3> path1;
	
    void Start()
    {

    /*    path2 = new Dictionary<int, Vector3>();
        GameObject[] pointArr2 = GameObject.FindGameObjectsWithTag("path2");
        foreach (GameObject go in pointArr2)
        {
            pathIndex script = go.GetComponent<pathIndex>();
            path2.Add(script.index, go.transform.position);
        }
		 
		 
		path3 = new Dictionary<int, Vector3>();
        GameObject[] pointArr3 = GameObject.FindGameObjectsWithTag("path3");
        foreach (GameObject go in pointArr3)
        {
            pathIndex script = go.GetComponent<pathIndex>();
            path3.Add(script.index, go.transform.position);
        } 		 
		 */
		
        path1 = new Dictionary<int, Vector3>();
        GameObject[] pointArr1 = GameObject.FindGameObjectsWithTag("path1");
        foreach (GameObject go in pointArr1)
        {
            pathIndex script = go.GetComponent<pathIndex>();
            path1.Add(script.index, go.transform.position);
        }
    }
}
