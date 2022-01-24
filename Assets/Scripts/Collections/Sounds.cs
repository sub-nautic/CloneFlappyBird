using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyBird.Collections
{
    [System.Serializable]
    public class Sounds
    {
        public AudioClip Clip;
        [Range(0.0f, 1f)]
        public float Volume = 1f;
        public string Name;
    }
}
