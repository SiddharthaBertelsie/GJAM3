using UnityEngine;

namespace GJAM3.Enemy
{
    public class AttackStateGoblin : AttackStateManager
    {
        #region Variables

        [Header("Scripts")]

        [SerializeField] private GoblinSFXPlayer _goblinSFXPlayer;

        [SerializeField] private FireballShooter _fireballShooter;

        #endregion

        #region Methods

        protected override void Attack()
        {
            if (_enemyHealthManager.GetIsAliveValue() && GameToggler.instance.GameStarted)
            {
                if (_playerApproacher.DistanceFromPlayerCheck() == true && timeUntilAttacking <= 0)
                {
                    switch (isDelayOver)
                    {
                        case false:
                            if (timeUntilAttacking <= 0)
                            {
                                timeUntilAttacking += attackDelayAmount;
                            }
                            break;
                        case true:
                            Debug.Log("We've met the conditions to attack the player");
                            // Instantiate fire ball here
                            _fireballShooter.ShootFireball();

                            // If fire ball has been fired, run this code
                            if (_fireballShooter.GetHasFiredFireball())
                            {
                                timeUntilAttacking += attackCooldown;
                                _goblinSFXPlayer.PlaySoundEffect(1, transform.position, 1, Random.Range(0.8f, 1.2f));
                            }
                            break;
                    }
                }
            }
        }

        protected override void InitializeVariables()
        {
            attackDamage = _enemyData.AttackDamage;
            distanceToAttackFrom = _enemyData.DistanceToAttackFrom;
            attackCooldown = _enemyData.AttackCooldown;
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitializeVariables();
        }

        // Update is called once per frame
        void Update()
        {
            Attack();
            CooldownAttack();
            DelayAttack();
        }

        #endregion
    }
}