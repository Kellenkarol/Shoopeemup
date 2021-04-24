using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpawn : MonoBehaviour
{
	public float distance, speed;
	// float leftDist, rightDist;
	bool movingRight=true;
	Vector3 posAux, camPos, startPos;
    // Start is called before the first frame update
    void Start()
    {
    	startPos = transform.position;
        // camPos 		= Camera.main.transform.position;
        // camPos 		= Camera.main.ScreenToWorldPoint(Camera.main.transform.position);
        // rightDist 	= camPos.x + Screen.width/2;
        // leftDist 	= camPos.x - Screen.width/2;
        // print(Screen.width/2);
    }

    // Update is called once per frame
    void Update()
    {
    	if(movingRight)
    	{
	        posAux = transform.position + transform.right*speed;
	        if(posAux.x > startPos.x-distance)
	        {
		        transform.position = posAux; 
	        }
	        else
	        {
	        	movingRight = false;
	        }
    	}
    	else
    	{
	        posAux = transform.position - transform.right*speed;
	        if(posAux.x < startPos.x+distance)
	        {
		        transform.position = posAux; 
	        }
	        else
	        {
	        	movingRight = true;
	        }
    	}
    }
}
