using UnityEngine;

namespace GJAM3.Enemy
{
    public class EnemyHealthManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private float _enemyHealth;

        [SerializeField] private float _enemyMaxHealth;

        [SerializeField] private EnemyData _enemyData;

        [SerializeField] private bool _isAlive;

        #endregion

        #region Debug Variables

        [SerializeField] private bool debugMode = false;

        #endregion

        #region Methods

        public void IncrementHealth(float valueToChangeBy)
        {
            _enemyHealth += valueToChangeBy;
        }

        public void DecrementHealth(float valueToChangeBy)
        {
            _enemyHealth -= valueToChangeBy;
            Debug.Log("Ouch! I've been dealt [" + valueToChangeBy + "] of damage!");
        }

        public void SetHealth(float valueToChangeBy)
        {
            _enemyHealth = valueToChangeBy;
        }

        public float GetHealth()
        {
            return _enemyHealth;
        }

        public float GetMaxHealth()
        {
            return _enemyMaxHealth;
        }

        public bool GetIsAliveValue()
        {
            return _isAlive;
        }

        private void CheckForDeath()
        {
            if (_enemyHealth <= 0)
            {
                Debug.Log("Oh no! I've died!");
                _isAlive = false;
            }
        }

        private void InitializeVariables()
        {
            _enemyMaxHealth = _enemyData.StartingHealth;
            _enemyHealth = _enemyMaxHealth;
            _isAlive = true;
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitializeVariables();
            SetHealth(_enemyMaxHealth);

            Debug.Log("The health of the AI is now: " + _enemyHealth);
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
                _enemyHealth = 0;
            }
        }

        #endregion
    }
}