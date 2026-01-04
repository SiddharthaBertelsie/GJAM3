using System.Collections;
using UnityEngine;

namespace GJAM3.Enemy
{
    public class AttackStateSnake : AttackStateManager
    {
        #region Variables

        private Coroutine _onInAttackDistance;

        [SerializeField] private SnakeSFXPlayer _snakeSFXPlayer;

        #endregion

        #region Methods

        protected override void Attack()
        {
            if (_enemyHealthManager.GetIsAliveValue() && GameToggler.instance.GameStarted)
            {
                if (_playerApproacher.DistanceFromPlayerCheck() == true && timeUntilAttacking <= 0)
                {
                    Debug.Log("We've met the conditions to attack the player");
                    timeUntilAttacking += attackCooldown;
                    _snakeSFXPlayer.PlaySoundEffect(1, transform.position, 1, Random.Range(0.8f, 1.2f));
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