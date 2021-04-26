using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDamagePlayer : MonoBehaviour
{
	public Image[] imgs;
	public Image back, lifeBar;
	public Text lifeValue;

	private Color red = new Color(1f,0f,0f,1f), 
				  green = new Color(0f,1f,0f,1f), 
				  white = new Color(1f,1f,1f,1f);

	bool playLastTime;


    // Start is called before the first frame update
    void Start()
    {
    	lifeBar.fillAmount = 1f;
    	lifeValue.text = Mathf.Ceil(lifeBar.fillAmount*100)+"%";
    	// Damage(450, 120);
    	// KillSomenthing();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void Damage(float maxLife, float currentLife)
    {
        StartCoroutine(_Damage(maxLife, currentLife));

    }


    private IEnumerator _Damage(float maxLife, float currentLife)
    {
    		if(!playLastTime)
    		{
		    	SoundManager.PlaySound("danoNave");
    		}
	    	lifeBar.fillAmount = currentLife/maxLife;
	    	lifeValue.text = Mathf.Ceil(lifeBar.fillAmount*100)+"%";
	    	if(Mathf.Ceil(lifeBar.fillAmount*100)!=0)
	    	{
		    	imgs[0].gameObject.SetActive(false);
		    	imgs[1].gameObject.SetActive(false);
		    	imgs[2].gameObject.SetActive(true);
		    	// back.color = red;
		    	yield return new WaitForSeconds(0.5f); 
		    	// back.color = white;
		    	if(Mathf.Ceil(lifeBar.fillAmount*100)!=0)
		    	{
			    	imgs[2].gameObject.SetActive(false);
			    	imgs[0].gameObject.SetActive(true);
		    	}
		    	yield return new WaitForSeconds(2); 
	    	}
	    	else
	    	{
	    		playLastTime = true;
		    	imgs[2].gameObject.SetActive(true);
	    	}
	    	yield return null;
    }


    public void KillSomenthing()
    {
    	StartCoroutine("_KillSomenthing");
    }


    private IEnumerator _KillSomenthing()
    {
    	// while(true)
    	// {

    	imgs[2].gameObject.SetActive(false);
    	imgs[1].gameObject.SetActive(true);
    	// back.color = green;
    	yield return new WaitForSeconds(0.75f); 
    	// back.color = white;
    	imgs[1].gameObject.SetActive(false);
    	yield return new WaitForSeconds(2); 

    	// }
    }
}
