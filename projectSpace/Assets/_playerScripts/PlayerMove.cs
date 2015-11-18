using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed;
    public float rotateSpeed;
    int health = 10;
	
	// Use this for initialization
    void start() {
       
    }
    void Update () {
        float move = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        if (move != 0)
            transform.Translate(0, 0, move * Time.deltaTime * speed);
        if (rotate != 0)
           transform.Rotate(0, rotate * Time.deltaTime * rotateSpeed, 0);
		
		
		 if (health <= 0)
		{
			Destroy(gameObject);
		}
                   
    }
	
	public void Death ()
	{
		animation.wrapMode = WrapMode.Once;
		health	= 0;
				
	}
}
