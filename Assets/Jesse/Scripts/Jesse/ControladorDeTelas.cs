using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeTelas : MonoBehaviour
{
	public Slider volumeSlider;
	public AudioSource audio;
	public Text input;

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
    	// recomeça nível
    }

    public void Enter()
    {
    	if(input.text.Length == 3)
    	{
    		print(input.text);
    		// salve o nick do input
    		// passe para a tela de pontuação
    	}
    }


    public void ChangeVolume()
    {
    	PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    	audio.volume = volumeSlider.value;
    }


}
