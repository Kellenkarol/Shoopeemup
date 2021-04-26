using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider sliderVolume;

    public GameObject GameObjectMusic;
    private AudioSource[] AudioSources;
    public static AudioSource[] AudioSourcesStatic;

    // Start is called before the first frame update
    void Start()
    {
        AudioSources = GetAudio(GameObjectMusic);
        AudioSourcesStatic = AudioSources;
        sliderVolume.value = PlayerPrefs.GetFloat("Volume", .5f);
        SetVolume();
    }


    public void SetVolume()
    {
        foreach(AudioSource _as in AudioSources)
        {
            _as.volume = sliderVolume.value; 
        }
    }


    private AudioSource[] GetAudio(GameObject MusicGameObject)
    {
        return MusicGameObject.GetComponentsInChildren<AudioSource>(); 
    }


    public static void PlaySound(string name)
    {
    	if(Switch(name) != -1)
    	{
	    	AudioSourcesStatic[Switch(name)].Play();
    	}
    }


    public static void StopSound(string name)
    {
    	if(Switch(name) != -1)
    	{
	    	AudioSourcesStatic[Switch(name)].Stop();
    	}
    }


    private static int Switch(string name)
    {
    	switch(name)
    	{
    		case "back": 				return 0;
    		case "ok": 					return 1;
    		case "opcional": 			return 2;
    		case "start": 				return 3;
    		case "energia": 			return 4;
    		case "escudo": 				return 5;
    		case "explosaoMeteoro": 	return 6;
    		case "gameOver": 			return 7;
    		case "gameWin": 			return 8;
    		case "danoMeteoro": 		return 9;
    		case "danoNaveInimiga": 	return 10;
    		case "explosaoNaveInimiga": return 11;
    		case "naveInimiga": 		return 12;
    		case "danoNave": 			return 13;
    		case "tiroInimigo": 		return 14;
    		case "tiro": 				return 15;
    		case "vida": 				return 16;
    	}
    	return -1;
    }


    public static void StopAllSounds()
    {
    	foreach(AudioSource aud in AudioSourcesStatic)
    	{
    		aud.Stop();
    	}
    }


}
