using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;

namespace General
{
    public enum AudioList
    {
        menuMusic,
        gameplayMusic,
        enemyDamaged,
        enemyDestroyed,
        shieldDamaged,
        shieldDestroyed,
        playerDamaged,
        playerDestroyed,
        playerShoot,
        enemyShoot,
        playerShield,
        energyCollected,
        fuelCollected,
        healthCollected
    }

    public class AudioManager : MonoBehaviour
    {
        [SerializeField] [Range(0f, 1f)] private float masterVolume = .5f;
        [SerializeField] private Sound[] sounds;
        
        private AudioList currentSong;

        private void Awake()
        {
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume * masterVolume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        public void Play(AudioList name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null || s.source.clip == null) return;

            s.source.Stop();
            s.source.Play();

            currentSong = name;
        }

        public void Stop(AudioList name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null || s.source.clip == null) return;

            s.source.Stop();
        }

        public void Pause(AudioList name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null || s.source.clip == null) return;

            s.source.Pause();
        }

        public void UnPause(AudioList name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null || s.source.clip == null) return;

            s.source.UnPause();
        }

        public void SetVolume(float volume)
        {
            Sound s = Array.Find(sounds, sound => sound.name == currentSong);

            if (s == null || s.source.clip == null) return;

            s.source.volume = volume * masterVolume;
        }

        public void FadeOut(AudioList name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null || s.source.clip == null) return;
            
            StartCoroutine(Fade(-.5f));
        }

        public void FadeIn(AudioList name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null || s.source.clip == null) return;

            StartCoroutine(Fade(.5f));
        }

        private IEnumerator Fade(float fadeValue)
        {
            Sound s = Array.Find(sounds, sound => sound.name == currentSong);

            if (fadeValue < 0)
            {
                while (s.source.volume > 0)
                {
                    s.source.volume -= fadeValue * Time.deltaTime;
                    yield return null;
                }

                Stop(currentSong);
                SetVolume(1f);
            }

            else
            {
                while (s.source.volume < 1)
                {
                    s.source.volume += fadeValue * Time.deltaTime;
                    yield return null;
                }
            }
        }
    }
}
