using UnityEngine;

namespace GJAM3.Enemy
{
    public abstract class AttackStateManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] protected EnemyData _enemyData;

        [SerializeField] protected float attackDamage;

        [SerializeField] protected float distanceToAttackFrom;

        [SerializeField] protected float attackCooldown;

        [SerializeField] protected float timeUntilAttacking;

        protected Coroutine attackCoroutine = null;

        [Header("Scripts")]

        [SerializeField] protected PlayerApproacher _playerApproacher;

        #endregion

        #region Methods

        protected abstract void Attack();

        protected abstract void InitializeVariables();

        protected void CooldownAttack()
        {
            if (timeUntilAttacking > 0)
            {
                timeUntilAttacking -= Time.deltaTime;
            }
        }

        protected void EndAttackCoroutine(Coroutine coroutineToEnd)
        {
            StopCoroutine(coroutineToEnd);
            coroutineToEnd = null;
        }

        #endregion
    }
}