using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBattery : MonoBehaviour
{
	public Image batteryImg;
	public Text num;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TestUpdate");
    }

    // Update is called once per frame
    void Update()
    {
        // print(Mathf.Ceil(0.8f/0.125f));
    }

    public void UpdateBatteryFill(float fillAmountFull, float currentFillAmount)
    {
    	float f = currentFillAmount*100/fillAmountFull;
    	UpdateNum(f);

    	f = currentFillAmount/fillAmountFull;
    	batteryImg.fillAmount = Mathf.Ceil(f/0.125f)*0.125f;

    }


    private void UpdateNum(float percent)
    {
    	num.text = (percent >= 0 ? percent : 0)+"%";
    }


    //Test
    public IEnumerator TestUpdate()
    {
    	yield return new WaitForSeconds(2);
    	float aux=0;
    	while(true)
    	{
    		aux += 1;
	    	UpdateBatteryFill(100,100-aux);
	    	yield return new WaitForSeconds(0.5f);
    	}
    }


}
