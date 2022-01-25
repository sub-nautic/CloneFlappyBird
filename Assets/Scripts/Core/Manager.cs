using System.Collections;
using System.Collections.Generic;
using FluffyBird.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyBird.Core
{
    public class Manager : MonoBehaviour
    {
        [SerializeField]
        private Game gameHandler;

        [SerializeField]
        private Animator animatorUI;

        [SerializeField]
        private Animator animatorFade;

        [SerializeField]
        private AudioManager audioManager;

        [SerializeField]
        private Button resetButton;

        [SerializeField]
        private Button leadboardButton;

        [SerializeField]
        private TMP_Text scoreText;

        [SerializeField]
        private TMP_Text scoreEndText;

        [SerializeField]
        private TMP_Text scoreBestText;

        private int bestScore = 0;
        private int score = 0;

        private void Start()
        {
            InitialiseGame();
        }

        public void HitObstacle()
        {
            gameHandler.StopObsticles();
            gameHandler.CanPlay = false;
        }

        public void HitGround()
        {
            gameHandler.GetBirdRigidbody2D().isKinematic = true;
            gameHandler.GetBirdRigidbody2D().velocity = Vector3.zero;
            gameHandler.HasGameStarted = false;
            gameHandler.CanPlay = false;
            gameHandler.GetBirdAnimator().SetBool("canFly", false);
            HitObstacle();
            UpdateEndScore();
            resetButton.interactable = true;
            leadboardButton.interactable = true;
        }

        public void RestartGame()
        {
            animatorUI.SetTrigger("Restart");
            resetButton.interactable = false;
        }

        public void Leadboard()
        {
            animatorUI.SetTrigger("Leadboard");
            leadboardButton.interactable = false;
        }

        public void AddPoint()
        {
            score += 1;
            scoreText.text = score.ToString();
        }

        private void InitialiseGame()
        {
            animatorUI.SetTrigger("Start");
        }

        private void UpdateEndScore()
        {
            scoreEndText.text = score.ToString();
            scoreBestText.text = bestScore.ToString();
            if (score > bestScore)
            {
                bestScore = score;
            }
        }

        private void ResetScoreBoard()
        {
            score = 0;
            scoreText.text = score.ToString();
        }

        public Animator GetUIAnimator()
        {
            return animatorUI;
        }

        public Animator GetFadeAnimator()
        {
            return animatorFade;
        }

        #region AnimationEvents

        public void TooltipStartAnimation()
        {
            animatorUI.SetTrigger("Start");
        }

        public void PrepareGame()
        {
            gameHandler.PrepareToStart();
        }

        public void HideEndLabelsAnimation()
        {
            animatorUI.SetTrigger("HideEnd");
        }

        public void EndScreenAnimation()
        {
            animatorUI.SetTrigger("End");
        }

        public void CanActiveStateChange()
        {
            gameHandler.CanPlay = true;
        }

        public void PlayMenuSound()
        {
            audioManager.PlaySound("Menu");
        }

        public void Restart()
        {
            ResetScoreBoard();
            animatorFade.SetTrigger("BlackScreen");
        }

        #endregion
    }
}