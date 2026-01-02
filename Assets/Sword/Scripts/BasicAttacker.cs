using UnityEngine;
using GJAM3.Player;
using GJAM3.Enemy;

namespace GJAM3.Sword
{
    public class BasicAttacker : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private bool _hasHitEnemy;

        [SerializeField] private float _attackDamage;

        [Header("Current Enemy Attacked")]

        [SerializeField] private EnemyHealthManager _currentEnemyAttacked;

        [Header("Scripts")]

        [Tooltip("We need this to know when the left mouse button has been pressed.")]
        [SerializeField] private InputManager _inputManager;

        [SerializeField] private SwordAnimationManager _swordAnimationManager;

        #endregion

        #region Methods

        private void PerformAttack()
        {
            if (GameToggler.instance.GameStarted)
            {
                // Greater than 0.1 means the button has been pressed
                if (_inputManager.GetBasicAttackInputValue() == true && _swordAnimationManager.CheckIfCanPlayAnimation() == true)
                {
                    Debug.Log("Attack!");
                    _swordAnimationManager.PlayBasicAttackAnimation();

                    if (_hasHitEnemy)
                    {
                        if (_currentEnemyAttacked != null)
                        {
                            Debug.Log("We have damaged the enemy!");
                            _currentEnemyAttacked.DecrementHealth(_attackDamage);
                        }
                    }
                }
            }
        }

        #endregion

        #region Unity Methods

        // Update is called once per frame
        void Update()
        {
            PerformAttack();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                Debug.Log("An enemy is in range");
                _hasHitEnemy = true;
                _currentEnemyAttacked = collision.GetComponent<EnemyHealthManager>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                Debug.Log("The enemy is now out of range");
                _hasHitEnemy = false;
                _currentEnemyAttacked = null;
            }
        }

        #endregion
    }
}