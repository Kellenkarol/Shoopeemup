using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    // [SerializeField]int menuValueController;
    // public GameObject selectButton;
    
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        /*if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (menuValueController > 0)
            {

                menuValueController--;
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (menuValueController < 3)
            {
                menuValueController++;
            }
        }*/
        // positionUISelectButton();
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     activeButton();
        // }
    // }

    // void positionUISelectButton()
    // {
    //     selectButton.transform.localPosition = new Vector3(0, 63- (menuValueController*44), 0);
    // }
    // void activeButton()
    // {
    //     switch (menuValueController)
    //     {
    //         case 0:
    //             SceneManager.LoadScene(1);
    //             break;
    //         case 1:
    //             SceneManager.LoadScene("Settings");
    //             break;
    //         case 2:
    //             SceneManager.LoadScene("Creditos");
    //             break;
    //         case 3:
    //             Application.Quit();
    //             break;
    //     }
    // }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
