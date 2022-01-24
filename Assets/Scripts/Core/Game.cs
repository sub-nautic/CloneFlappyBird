using System.Collections;
using System.Collections.Generic;
using FluffyBird.Collections;
using FluffyBird.Bird;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FluffyBird.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private Manager manager;

        [SerializeField]
        private Player bird;

        [SerializeField]
        private Obsticle obsticle;

        [SerializeField]
        private Transform ground;

        [SerializeField]
        private ObsticleSetting obsticleSetting;

        [SerializeField]
        private Transform spawnPos;

        [SerializeField]
        private AudioManager audioManager;

        private const float JUMP_SPEED = 20f;
        private const int OBSTICLE_AMOUNT = 6;
        private const float GROUND_RESET_DISCTANCE = 4.1f;

        private List<Obsticle> obsticles = new List<Obsticle>();

        private Rigidbody2D birdRB;
        private BirdInput birdInput;
        private Animator birdAnimator;
        private Transform obsticleRoot;
        private Coroutine obsticleGenerator;
        private Vector3 startGroundPos;
        private int currentObsticlePooled = 0;

        public bool IsGameStarted = false;
        public bool CanActive = false;

        private void Awake()
        {
            SetupInput();
        }

        private void Start()
        {
            GenerateObsticles();
            bird = Instantiate(bird, spawnPos.position, spawnPos.rotation);
            birdRB = bird.GetBirdRigidbody2D();
            birdAnimator = bird.GetComponent<Animator>();
            startGroundPos = ground.position;
            PrepareToStart();
        }

        private void Update()
        {
            if (CanActive)
            {
                GroundMovement();
            }
        }

        public void PrepareToStart()
        {
            DisableObsticles();
            birdRB.isKinematic = true;
            bird.transform.position = spawnPos.position;
            bird.transform.rotation = spawnPos.rotation;
            birdAnimator.SetBool("canFly", true);
        }

        public void StartGame()
        {
            birdRB.isKinematic = false;
            obsticleGenerator = StartCoroutine(GenerateStructure());
            manager.GetUIAnimator().SetTrigger("StartPlay");
            IsGameStarted = true;
        }

        public void StopObsticles()
        {
            StopCoroutine(obsticleGenerator);
            foreach (Obsticle obsticle in obsticles)
            {
                obsticle.CanMove = false;
            }
        }

        private void SetupInput()
        {
            birdInput = new BirdInput();
            birdInput.Bird.Enable();
            birdInput.Bird.Jump.performed += Jump;
            birdInput.Bird.Quit.performed += QuitGame;
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            if (obj.performed && CanActive)
            {
                if (!IsGameStarted)
                {
                    StartGame();
                }

                birdRB.velocity = Vector2.zero;
                birdRB.angularVelocity = 0;
                birdRB.velocity = Vector2.up * JUMP_SPEED;
                audioManager.PlaySound("Fly");
            }
        }

        private void QuitGame(InputAction.CallbackContext obj)
        {
            if (obj.performed)
            {
                Application.Quit();
            }
        }

        private void GenerateObsticles()
        {
            if (obsticleRoot == null)
            {
                obsticleRoot = new GameObject().transform;
                obsticleRoot.name = $"ObsticleRoot";
            }

            for (int i = 0; i <= OBSTICLE_AMOUNT - 1; i++)
            {
                Obsticle obj = Instantiate(obsticle);
                obj.transform.SetParent(obsticleRoot);
                obsticles.Add(obj);
            }
        }

        private IEnumerator GenerateStructure()
        {
            Obsticle currObsticle = obsticles[currentObsticlePooled];

            Vector3 spawnPos = new Vector3(obsticleSetting.SpawnDistanceOffset, 0f, 0f);
            Vector3 spawnHeight = new Vector3(0f, Random.Range(0f, obsticleSetting.HeightVariationMax), 0f);
            currObsticle.transform.position = spawnPos + spawnHeight;
            currObsticle.gameObject.SetActive(true);

            currentObsticlePooled++;
            if (currentObsticlePooled > obsticles.Count - 1)
            {
                currentObsticlePooled = 0;
            }

            yield return new WaitForSeconds(obsticleSetting.ObsticleResetDelay);

            obsticleGenerator = StartCoroutine(GenerateStructure());
        }

        private void DisableObsticles()
        {
            foreach (Obsticle obsticle in obsticles)
            {
                obsticle.gameObject.SetActive(false);
            }
        }

        private void GroundMovement()
        {
            ground.Translate(Vector3.left * Time.deltaTime * obsticleSetting.ObsticleMoveSpeed);

            if (ground.position.x < GROUND_RESET_DISCTANCE)
            {
                ground.position = startGroundPos;
            }
        }

        public ObsticleSetting GetObsticleSetting()
        {
            return obsticleSetting;
        }

        public Rigidbody2D GetBirdRigidbody2D()
        {
            return birdRB;
        }

        public Animator GetBirdAnimator()
        {
            return birdAnimator;
        }
    }
}