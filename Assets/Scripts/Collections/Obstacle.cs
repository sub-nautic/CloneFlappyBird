using System.Collections;
using System.Collections.Generic;
using FluffyBird.Core;
using UnityEngine;

namespace FluffyBird.Collections
{
    public class Obstacle : MonoBehaviour
    {
        public bool CanMove = true;

        private const float DISTANCE_TO_DISABLE = -2f;

        private Game gameHandler;
        private float obstacleSpeed;

        private void Awake()
        {
            gameHandler = FindObjectOfType<Game>();
        }

        private void Start()
        {
            obstacleSpeed = gameHandler.GetObstacleSetting().ObstacleMoveSpeed;
        }

        private void OnEnable()
        {
            CanMove = true;
        }

        private void Update()
        {
            if (CanMove)
            {
                transform.Translate(-Vector3.right * Time.deltaTime * obstacleSpeed);
            }
        }

        private void FixedUpdate()
        {
            if (transform.position.x <= DISTANCE_TO_DISABLE)
            {
                gameObject.SetActive(false);
            }
        }
    }
}