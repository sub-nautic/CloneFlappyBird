using System.Collections;
using System.Collections.Generic;
using FluffyBird.Core;
using UnityEngine;

namespace FluffyBird.Collections
{
    public class Obsticle : MonoBehaviour
    {
        [SerializeField]
        private Transform obsticleMeshTransform;

        public bool CanMove = true;

        private const float DISTANCE_TO_DISABLE = -2f;

        private Game gameHandler;
        private float obsticleSpeed;

        private void Awake()
        {
            gameHandler = FindObjectOfType<Game>();
        }

        private void Start()
        {
            obsticleSpeed = gameHandler.GetObsticleSetting().ObsticleMoveSpeed;
        }

        private void OnEnable()
        {
            CanMove = true;
        }

        private void Update()
        {
            if (CanMove)
            {
                transform.Translate(-Vector3.right * Time.deltaTime * obsticleSpeed);
            }
        }

        private void FixedUpdate()
        {
            if (transform.position.x <= DISTANCE_TO_DISABLE)
            {
                gameObject.SetActive(false);
            }
        }

        public Transform GetObsticleMeshTransform()
        {
            return obsticleMeshTransform;
        }
    }
}