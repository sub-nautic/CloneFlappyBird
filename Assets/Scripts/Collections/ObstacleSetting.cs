using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyBird.Collections
{
    [CreateAssetMenu(fileName = "ObstacleSetting", menuName = "FluffyBird/ObstacleSetting", order = 0)]
    public class ObstacleSetting : ScriptableObject
    {
        public float ObstacleMoveSpeed = 5f;
        public float ObstacleResetDelay = 1.3f;
        public float HeightVariationMax = -7f;
        public float SpawnDistanceOffset = 20f;
    }
}