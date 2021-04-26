using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public Slider volumeSlider;
	public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
    	volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        ChangeVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoMenu()
    {
    	// vai para o menu
    }

    public void Restart()
    {
    	PlayerPrefs.SetInt("Score", 0);
		SceneManager.LoadScene(0);
    	// recomeça nível
    }

    public void ChangeVolume()
    {
    	PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    	audio.volume = volumeSlider.value;
    }
}
