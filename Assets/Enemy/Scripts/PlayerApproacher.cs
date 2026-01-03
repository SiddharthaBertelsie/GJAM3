using UnityEngine;

namespace GJAM3.Enemy
{
    public class PlayerApproacher : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private EnemyData _enemyData;

        [Tooltip("The rate of speed the AI will move toward the player at")]
        [SerializeField] private float _approachingSpeed;

        [Tooltip("How close the AI needs to be to the player before attack them witn a close-ranged attack")]
        [SerializeField] private float _distanceToAttackFrom;

        // This bool is what tells this and other scripts when the AI has met or exceeded the specified distance between them and player
        [SerializeField] private bool isInAttackDistance;

        [Header("Components")]

        // The referecne to the player we move towards
        [SerializeField] private Transform playerTransform;

        [Header("Scripts")]

        [SerializeField] private EnemyHealthManager _enemyHealthManager;

        #endregion

        #region Methods
        public void MoveTowardPlayer()
        {
            if (_enemyHealthManager.GetIsAliveValue() && GameToggler.instance.GameStarted)
            {
                if (Vector2.Distance(transform.position, playerTransform.position) > _distanceToAttackFrom)
                {
                    transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, _approachingSpeed * Time.deltaTime);
                    //RotateTowardsPlayer();

                    SetIsInAttackDistanceValue(false);
                }
                else
                {
                    SetIsInAttackDistanceValue(true);
                }
            }
        }

        /// <summary>
        /// Called by MeleeEnemyAI to check value before moving into Attacking
        /// </summary>
        /// <returns></returns>
        public bool DistanceFromPlayerCheck()
        {
            return isInAttackDistance;
        }

        public void SetIsInAttackDistanceValue(bool value)
        {
            //Debug.Log("SetIsInAttackDistanceValue method has been called");
            isInAttackDistance = value;
        }

        public Transform GetPlayerTransform()
        {
            return playerTransform;
        }

        /// <summary>
        /// Rotates toward player while appraoching and not exceeding or meeting the attack distance
        /// </summary>
        private void RotateTowardsPlayer()
        {
            transform.LookAt(playerTransform.position, Vector3.up);
        }

        private void InitializeVariables()
        {
            _approachingSpeed = _enemyData.MovementSpeed;
            _distanceToAttackFrom = _enemyData.DistanceToAttackFrom;
            playerTransform = GlobalMethods.instance.GetPlayerTransform();
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitializeVariables();
        }

        private void Update()
        {
            MoveTowardPlayer();
        }

        #endregion
    }
}