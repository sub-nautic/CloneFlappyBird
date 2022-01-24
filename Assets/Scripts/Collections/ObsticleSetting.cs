using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyBird.Collections
{
    [CreateAssetMenu(fileName = "ObsticleSetting", menuName = "FluffyBird/ObsticleSetting", order = 0)]
    public class ObsticleSetting : ScriptableObject
    {
        public float ObsticleMoveSpeed = 5f;
        public float ObsticleResetDelay = 1f;
        public float HeightVariationMax = -11f;
        public float SpawnDistanceOffset = 20f;
    }
}