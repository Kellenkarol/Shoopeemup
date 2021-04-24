using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
	public Renderer rend;
	public float speed;
	float offset=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        offset += Time.deltaTime*speed/100;
    }
}
