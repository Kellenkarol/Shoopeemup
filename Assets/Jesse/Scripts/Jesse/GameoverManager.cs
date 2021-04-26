using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverManager : MonoBehaviour
{
	// public bool IsInGameoverScene;
	public Text input;
	public GameObject gameOverScreen, gameOverScoreScreen, fadeIn, fadeOut;
    // Start is called before the first frame update
    void Start()
    {
    	// if(!IsInGameoverScene)
    	// {
    	// 	StartGameOver();
    	// }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GoMenu()
    {
    	StartCoroutine("_GoMenu");
    }


    public IEnumerator _GoMenu()
    {
    	fadeOut.SetActive(true);
    	yield return new WaitForSeconds(1.2f);
		SceneManager.LoadScene(0);
    }


    public void Restart()
    {
    	StartCoroutine("_Restart");
    }


    public IEnumerator _Restart()
    {
    	fadeOut.SetActive(true);
    	yield return new WaitForSeconds(1.2f);
		SceneManager.LoadScene(1);
    }


    public void EnterNick()
    {
    	if(input.text.Length == 3)
    	{
    		print(input.text);
    		//float score = PlayerPrefs.GetInt("Score");
    		// passe para a tela de pontuação
    		gameOverScreen.SetActive(false);
    		gameOverScoreScreen.SetActive(true);

    	}
    }

    public void StartGameOver()
    {	
    	StartCoroutine("_StartGameOver");
    }

    private IEnumerator _StartGameOver()
    {
    	yield return new WaitForSeconds(1.5f);
    	fadeOut.SetActive(true);
    	yield return new WaitForSeconds(1.2f);
		SceneManager.LoadScene(2);

    }

}
