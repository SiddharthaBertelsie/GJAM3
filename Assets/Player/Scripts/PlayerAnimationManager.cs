using UnityEngine;

namespace GJAM3.Player
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        #region Variables

        [Header("Components")]

        [SerializeField] private Animator _playerAnimator;

        [Header("Scripts")]

        [SerializeField] private PlayerController _playerController;

        [SerializeField] private InputManager _inputManager;

        #endregion

        #region Methods

        private void ChangeWalkAnimation()
        {
            switch (_inputManager.GetPlayerMovementValue().x)
            {
                case > 0:
                    ResetAllTriggers();
                    _playerAnimator.SetTrigger("moveRight");
                    break;
                case < 0:
                    ResetAllTriggers();
                    _playerAnimator.SetTrigger("moveLeft");
                    break;
                default:
                    break;
            }
            switch (_inputManager.GetPlayerMovementValue().y)
            {
                case > 0:
                    ResetAllTriggers();
                    _playerAnimator.SetTrigger("moveUp");
                    break;
                case < 0:
                    ResetAllTriggers();
                    _playerAnimator.SetTrigger("moveDown");
                    break;
                default:
                    break;
            }

            if (_inputManager.GetPlayerMovementValue() == Vector2.zero)
            {
                ResetAllTriggers();
                _playerAnimator.SetTrigger("idle");
            }
        }

        private void ResetAllTriggers()
        {
            _playerAnimator.ResetTrigger("moveUp");
            _playerAnimator.ResetTrigger("moveDown");
            _playerAnimator.ResetTrigger("moveLeft");
            _playerAnimator.ResetTrigger("moveRight");
            _playerAnimator.ResetTrigger("idle");
        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            ChangeWalkAnimation();
        }

        #endregion
    }
}