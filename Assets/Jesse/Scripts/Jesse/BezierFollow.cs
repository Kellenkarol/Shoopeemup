using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
	[SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector2 objectPosition;

    public float speedModifier;

    private bool coroutineAllowed;

    // Start is called before the first frame update
    void Start()
    {
    	if(routes.Length != 0)
    	{
    		// Quaternion targetRotation = Quaternion.LookRotation (routes[0].transform.parent.transform.position - transform.position);
    		// transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 200);
	    	transform.rotation = routes[0].transform.parent.transform.rotation;
	    	transform.Rotate(0.0f, 0.0f, 180.0f, Space.World);
	    	// transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.x,20,transform.rotation.w);
    	}
        routeToGo = 0;
        tParam = 0f;
        // speedModifier = 0.5f;
        coroutineAllowed = true;
        StartCoroutine(GoByTheRoute(routeToGo));
    }

    private IEnumerator GoByTheRoute(int routeNum)
    {
        coroutineAllowed = false;

        Vector2 p0 = routes[routeNum].GetChild(0).position;
        Vector2 p1 = routes[routeNum].GetChild(1).position;
        Vector2 p2 = routes[routeNum].GetChild(2).position;
        Vector2 p3 = routes[routeNum].GetChild(3).position;

        while(tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            transform.position = objectPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        routeToGo += 1;

        if(routeToGo < routes.Length)
        {
			StartCoroutine(GoByTheRoute(routeToGo));
        }
        else
        {
        	Destroy(this.gameObject);
        }

    }
}
