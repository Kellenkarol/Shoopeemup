using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpawn : MonoBehaviour
{
	public float distance, speed;

	bool movingRight=true;
	Vector3 posAux, camPos, startPos;


    // Start is called before the first frame update
    void Start()
    {
    	startPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
    	if(movingRight)
    	{
	        posAux = transform.position + transform.right*speed;
    	}
    	else
    	{
	        posAux = transform.position - transform.right*speed;
    	}
        float magn = Magnitude(posAux, startPos);
        if(magn < distance)
        {
        	// print("Oxe painho");
	        transform.position = posAux; 
        }
        else
        {
        	movingRight = !movingRight;
        }
    }

    private float Magnitude(Vector3 a, Vector3 b)
    {
    	return Mathf.Sqrt((b.x-a.x)*(b.x-a.x)+(b.y-a.y)*(b.y-a.y));
    }
}
