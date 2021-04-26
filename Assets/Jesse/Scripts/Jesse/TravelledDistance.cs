using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelledDistance : MonoBehaviour
{
	private Text text;
	float dist=0;
    // Start is called before the first frame update
    void Start()
    {
    	text = GetComponent<Text>();  
        print(dist);  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	dist += Time.fixedDeltaTime;
        PlayerPrefs.SetInt("Score", (int)(dist));
        text.text = ((int)(dist)).ToString();
    }
}
