using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingsScript : MonoBehaviour
{
    public float volumeValue;
    public Slider volumeSlider;
    public int menuValueController;
    public GameObject selectButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        volumeValue = volumeSlider.value;
        positionUISelectButton();
    }

    void positionUISelectButton()
    {
        selectButton.transform.localPosition = new Vector3(-113.5f + (113.5f* menuValueController), -77.5f, 0);
    }

    void backMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
