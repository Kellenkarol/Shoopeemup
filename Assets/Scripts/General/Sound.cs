using UnityEngine.Audio;
using UnityEngine;

namespace General
{
    [System.Serializable]
    public class Sound
    {
        public AudioList name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;
        [Range(.5f, 1.5f)]
        public float pitch;

        public bool loop;

        [HideInInspector]
        public AudioSource source;
    }
}
