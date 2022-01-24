using System.Collections;
using System.Collections.Generic;
using FluffyBird.Core;
using UnityEngine;

namespace FluffyBird.Collections
{
    public class UIAnimator : MonoBehaviour
    {
        [SerializeField]
        private Game gameHandler;

        [SerializeField]
        private Manager manager;

        public void CanActiveStateChange()
        {
            gameHandler.CanPlay = true;
        }

        public void MenuSound()
        {
            manager.PlayMenuSound();
        }

        public void RestartGame()
        {
            manager.Restart();
        }
    }
}
