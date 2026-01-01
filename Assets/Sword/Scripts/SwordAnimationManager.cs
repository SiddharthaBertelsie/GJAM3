using UnityEngine;
using GJAM3.Player;

namespace GJAM3.Sword
{
    public class SwordAnimationManager : MonoBehaviour
    {
        #region Variables

        [Header("Animator")]

        [SerializeField] private Animator _swordAnimator;

        [SerializeField] private AnimationClip _animationClip;

        [SerializeField] private bool _isPlayingAnimation;

        [Header("Scripts")]

        [SerializeField] private InputManager _inputManager;

        #endregion

        #region Methods

        public void PlayBasicAttackAnimation()
        {
            _isPlayingAnimation = true;
            _swordAnimator.ResetTrigger("performBasicAttack");
            _swordAnimator.ResetTrigger("idle");

            _swordAnimator.SetTrigger("performBasicAttack");
        }

        public void ResetTriggers()
        {
            _swordAnimator.ResetTrigger("performBasicAttack");
            _swordAnimator.SetTrigger("idle");

            _swordAnimator.StopPlayback();
            _isPlayingAnimation = false;
        }

        public bool CheckIfIsAnimatorPlaying()
        {
            return _isPlayingAnimation;
        }

        #endregion
    }
}