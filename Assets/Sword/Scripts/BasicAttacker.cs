using UnityEngine;
using GJAM3.Player;

namespace GJAM3.Sword
{
    public class BasicAttacker : MonoBehaviour
    {
        #region Variables

        [Header("Scripts")]

        [Tooltip("We need this to know when the left mouse button has been pressed.")]
        [SerializeField] private InputManager _inputManager;

        [SerializeField] private SwordAnimationManager _swordAnimationManager;

        #endregion

        #region Methods

        private void PerformAttack()
        {
            // Greater than 0.1 means the button has been pressed
            if (_inputManager.GetBasicAttackInputValue() == true && _swordAnimationManager.CheckIfCanPlayAnimation() == true)
            {
                Debug.Log("Attack!");
                _swordAnimationManager.PlayBasicAttackAnimation();
            }
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            PerformAttack();
        }

        #endregion
    }
}