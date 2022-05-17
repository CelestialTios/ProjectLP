using UnityEngine;
using UnityEngine.Audio;
using System;

namespace Assets.Scripts.Utils
{
    [Serializable]
    public class Sound   
    {
        public string name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume = 1f;
        [Range(.1f, 3f)]
        public float pitch = 3f;

        public bool loop = false;

        [HideInInspector]
        public AudioSource source;

    }
}