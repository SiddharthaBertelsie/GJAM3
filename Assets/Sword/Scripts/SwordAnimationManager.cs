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

        [SerializeField] private bool _canPlayAnimation;

        [Header("Scripts")]

        [SerializeField] private InputManager _inputManager;

        #endregion

        #region Methods

        public void PlayBasicAttackAnimation()
        {
            _swordAnimator.ResetTrigger("idle");

            _swordAnimator.SetTrigger("performBasicAttack");
        }

        public void ResetTriggers()
        {
            _swordAnimator.ResetTrigger("performBasicAttack");

            _swordAnimator.SetTrigger("idle");
        }
        #endregion

        private void Start()
        {
            _swordAnimator.SetTrigger("idle");
        }
    }
}