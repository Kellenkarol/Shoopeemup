using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
	public GameObject imgTutorial, Ready, Go, block;
	public Animator animatorExit;
	private bool skip, finished;
	public static bool TutorialOn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ShowTutorial");
    }

    void Update()
    {
    	TutorialOn = !finished;
    }

    private IEnumerator ShowTutorial()
    {
    	Time.timeScale = 0f;
    	imgTutorial.SetActive(true);
    	// while(!skip)
    	// {
	    	// yield return null;
    	// }
    	animatorExit.SetBool("Skip", true);

    	yield return new WaitForSeconds(0.75f);
    	Ready.SetActive(true);
    	yield return new WaitForSeconds(1.75f);
    	Go.SetActive(true);
    	yield return new WaitForSeconds(0.5f);
    	imgTutorial.SetActive(false);
    	yield return new WaitForSeconds(1.5f);
    	Ready.SetActive(false);
    	block.SetActive(false);
    	yield return new WaitForSeconds(1.5f);
    	Go.SetActive(false);
    	finished=true;

    }


    public void Skip()
    {
    	Time.timeScale = 1f;
    	// skip=true;
    }

}
