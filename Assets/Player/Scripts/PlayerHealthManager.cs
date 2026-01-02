using UnityEngine;

namespace GJAM3.Player
{
    public class PlayerHealthManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private float _playerHealth;

        [SerializeField] private float _playerMaxHealth;

        #endregion

        #region Debug Variables

        [SerializeField] private bool debugMode = false;

        #endregion

        #region Methods

        public void IncrementHealth(float valueToChangeBy)
        {
            _playerHealth += valueToChangeBy;
            MenuManager.instance.UpdateHUDHealthText(_playerHealth);
        }

        public void DecrementHealth(float valueToChangeBy)
        {
            _playerHealth -= valueToChangeBy;
            Debug.Log("Ouch! I've been dealt [" + valueToChangeBy + "] of damage!");
            MenuManager.instance.UpdateHUDHealthText(_playerHealth);
        }

        public void SetHealth(float valueToChangeBy)
        {
            _playerHealth = valueToChangeBy;
        }

        public float GetHealth()
        {
            return _playerHealth;
        }

        public float GetMaxHealth()
        {
            return _playerMaxHealth;
        }

        private void CheckForDeath()
        {
            if (_playerHealth <= 0)
            {
                Debug.Log("Oh no! I've died!");
                MenuManager.instance.ToggleGameOverMenu(true);
                GameToggler.instance.ToggleGameStarted(false);
            }
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            SetHealth(_playerMaxHealth);

            Debug.Log("The health of the AI is now: " + _playerHealth);

            MenuManager.instance.UpdateHUDHealthText(GetHealth());
        }

        private void Update()
        {
            if (debugMode)
            {
                LowerHealthToZero();
            }

            CheckForDeath();
        }

        #endregion

        #region Debug Methods

        /// <summary>
        /// This method brings the health immeditly down to 5. This was used for testing while implementing the functionality of the Flee State
        /// </summary>

        private void LowerHealthToZero()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _playerHealth = 0;
            }
        }

        #endregion
    }
}