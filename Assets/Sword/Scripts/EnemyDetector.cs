using GJAM3.Enemy;
using UnityEngine;

namespace GJAM3.Sword
{
    public class EnemyDetector : MonoBehaviour
    {
        #region Variables

        [SerializeField] private bool _hasHitEnemy;

        [SerializeField] private EnemyHealthManager _enemyToAttack;

        #endregion

        #region Methods

        public bool GetHasHitEnemyValue()
        {
            return _hasHitEnemy;
        }

        public EnemyHealthManager GetEnemyToAttack()
        {
            return _enemyToAttack;
        }

        #endregion

        #region Unity Methods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Goblin"))
            {
                Debug.Log("An enemy is in range");
                _hasHitEnemy = true;
                _enemyToAttack = collision.GetComponent<EnemyHealthManager>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Goblin"))
            {
                Debug.Log("The enemy is now out of range");
                _hasHitEnemy = false;
                _enemyToAttack = null;
            }
        }

        #endregion
    }
}