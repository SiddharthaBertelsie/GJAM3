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

        [SerializeField] protected float attackDelayAmount;

        protected bool isDelayOver;

        protected Coroutine attackCoroutine = null;

        [Header("Scripts")]

        [SerializeField] protected PlayerApproacher _playerApproacher;

        [SerializeField] protected EnemyHealthManager _enemyHealthManager;

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

        protected void DelayAttack()
        {
            if (timeUntilAttacking > 0)
            {
                timeUntilAttacking -= Time.deltaTime;

                if (timeUntilAttacking <= 0)
                {
                    isDelayOver = true;
                }
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