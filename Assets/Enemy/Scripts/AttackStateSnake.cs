using System.Collections;
using UnityEngine;

namespace GJAM3.Enemy
{
    public class AttackStateSnake : AttackStateManager
    {
        #region Variables

        private Coroutine _onInAttackDistance;

        #endregion

        #region Methods

        protected override void Attack()
        {
            if (_enemyHealthManager.GetIsAliveValue() && GameStarter.instance.GameStarted)
            {
                if (_playerApproacher.DistanceFromPlayerCheck() == true && timeUntilAttacking <= 0)
                {
                    Debug.Log("We've met the conditions to attack the player");
                    timeUntilAttacking += attackCooldown;
                    GlobalMethods.instance.DamagePlayer(attackDamage);
                }
            }
        }

        protected override void InitializeVariables()
        {
            attackDamage = _enemyData.AttackDamage;
            distanceToAttackFrom = _enemyData.DistanceToAttackFrom;
            attackCooldown = _enemyData.AttackCooldown;

            _onInAttackDistance = null;
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitializeVariables();
        }

        private void Update()
        {
            Attack();
            CooldownAttack();
        }

        #endregion
    }
}