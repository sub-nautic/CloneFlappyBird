using System.Collections;
using System.Collections.Generic;
using FluffyBird.Collections;
using FluffyBird.Core;
using UnityEngine;

namespace FluffyBird.Bird
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private AudioManager audioManager;

        [SerializeField]
        private Rigidbody2D birdRigidbody2D;

        [SerializeField]
        private float rotationDownSpeed = 5f;

        private Manager manager;
        private Game gameHandler;

        private void Update()
        {
            FlyDown();
        }

        private void Awake()
        {
            manager = FindObjectOfType<Manager>();
            gameHandler = FindObjectOfType<Game>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obsticle") && gameHandler.CanActive)
            {
                manager.HitObsticle();
                manager.GetFadeAnimator().SetTrigger("WhiteScreen");
                audioManager.PlaySound("Hit");
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                if (gameHandler.CanActive)
                {
                    manager.GetFadeAnimator().SetTrigger("WhiteScreen");
                    audioManager.PlaySound("Hit");
                }

                manager.HitGround();
            }
            else
            {
                if (gameHandler.CanActive)
                {
                    manager.AddPoint();
                    audioManager.PlaySound("Point");
                }
            }
        }

        public void FlyDown()
        {
            if (gameHandler.IsGameStarted)
            {
                transform.eulerAngles = new Vector3(0f, 0f, birdRigidbody2D.velocity.y * rotationDownSpeed);
            }
        }

        public Rigidbody2D GetBirdRigidbody2D()
        {
            return birdRigidbody2D;
        }
    }
}