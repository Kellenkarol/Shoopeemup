using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overcharge : MonoBehaviour
{
	public Image imgBar, imgBarBlack, imgWeapon;
    public Text imgWarning;
	// public Image[] BarLinesImg;
	// public Image[] BarLinesImgBack;
	[Range(0, 100)]
	public int Shoots;
	public float OverchargeRecovery;
	private Color barColor;

	bool alertIn=true, overcharge;
	float auxTime;

    // Start is called before the first frame update
    void Start()
    {
        barColor = imgBar.color;
        StartCoroutine("AlertOvercharge");
    }

    // Update is called once per frame
    void Update()
    {
    	imgBarBlack.fillAmount = imgBar.fillAmount;
        ChangeBarFill(100, Shoots);
    }

    // public void ChangeBarFill(float v)
    // {
    // 	if(!overcharge)
    // 	{
	   //  	float percent = v*510/100;
	   //  	imgBar.fillAmount = v/100;
	   //  	imgBar.color = new Color((percent/255 <= 1 ? percent/255: 1), ((510-percent)/255 <= 1 ? (510-percent)/255 : 1), barColor[2]);
	   //  	imgBarBack.color = imgBar.color;
	   //  	ChangeBarLinesColor(imgBar.color);
    // 	}
    // }

    public void ChangeBarFill(int maxShoot, int currentShoots)
    {
    	if(!overcharge)
    	{
    		float v = currentShoots*100/maxShoot;
	    	float percent = v*510/100;
            imgBar.fillAmount = v/100;
	    	imgBar.color = new Color((percent/255 <= 1 ? percent/255: 1), ((510-percent)/255 <= 1 ? (510-percent)/255 : 1), barColor[2]);
            imgWeapon.color = imgBar.color;
            imgWeapon.color = imgBar.color;
            imgWarning.color = imgBar.color;
	    	// imgBarBack.color = imgBar.color;
	    	// ChangeBarLinesColor(imgBar.color);
    	}
    }


    private IEnumerator IsOvercharge()
    {
    	while(imgBar.fillAmount != 0)
    	{
    		// print("Debug here! "+imgBar.fillAmount);
	    	imgBar.fillAmount -= Time.deltaTime * OverchargeRecovery;
	    	float percent = imgBar.fillAmount*100*510/100;
	    	imgBar.color = new Color((percent/255 <= 1 ? percent/255: 1), ((510-percent)/255 <= 1 ? (510-percent)/255 : 1), barColor[2]);
            imgWeapon.color = imgBar.color;
            imgWarning.color = imgBar.color;
	    	// imgBarBack.color = imgBar.color;
	    	// ChangeBarLinesColor(imgBar.color);
	    	Shoots = 0;
	    	yield return null;
    	}
    }


    private IEnumerator AlertOvercharge()
    {
    	while(true)
    	{
    		if(!overcharge)
    		{
	    		if(imgBar.fillAmount == 1f)
	    		{
	    			StartCoroutine(IsOvercharge());
	    			overcharge = true;
	    			auxTime = 0;
	    		}
	    		else
	    		{
	    			auxTime += Time.deltaTime*imgBar.fillAmount*2;
	    		}
    		}
    		else
    		{
    			auxTime += Time.deltaTime*imgBar.fillAmount*7;
    		}

    		if(overcharge || imgBar.fillAmount >= 0.5f)
			{
    			// if(alertIn)
    			// {
    			// 	ShowIsOvercharge(auxTime/2+0.25f);
    			// }
    			// else
    			// {
    			// 	ShowIsOvercharge(0.75f-(auxTime/2));
    			// }

    			if(auxTime>=1)
    			{
    				auxTime = 0;
    				alertIn = !alertIn;
    			}

    			if(imgBar.fillAmount == 0)
    			{
    				overcharge = false;
    			}
			}
			// else
			// {
			// 	ChangeBarLinesAlert(0.5f);
			// }

    		yield return null;
    	}
    }

    // private void ShowIsOvercharge(float percent)
    // {
    //         imgBar.color = new Color( imgBar.color[0], imgBar.color[1], percent);
    //         imgWeapon.color = imgBar.color;
    //         imgWarning.color = imgBar.color;

    // }

    // private void ChangeBarLinesColor(Color c)
    // {
    // 	foreach(Image im in BarLinesImg)
    // 	{
    // 		im.color = c;
    // 	}
    // }
}
