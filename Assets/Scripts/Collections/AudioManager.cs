using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyBird.Collections
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        public Sounds[] clips;

        [SerializeField]
        private AudioSource audioSource;

        public void PlaySound(string sound)
        {
            Sounds audioClip = Array.Find(clips, item => item.Name == sound);

            if (audioClip != null)
            {
                audioSource.volume = audioClip.Volume;
                audioSource.clip = audioClip.Clip;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning($"Sound: {sound} not found!");
            }
        }
    }
}
