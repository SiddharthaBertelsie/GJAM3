using UnityEngine;
using GJAM3.Player;

namespace GJAM3.Sword
{
    public class DashSlasher : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private float _dashSlashSpeed;

        [SerializeField] private bool _canDashSlash;

        private bool _currentlyDashSlashing;

        [Header("Components")]

        [SerializeField] private Rigidbody2D _rigidBody;

        [Header("Scripts")]

        [SerializeField] private InputManager _inputManager;

        [SerializeField] private EnemyDetector _enemyDetector;

        [SerializeField] private SwordMover _swordMover;

        [SerializeField] private DashSlashEnabler _dashSlashEnabler;

        [SerializeField] private DashSlashHUDUpdater _dashSlashHUDUpdater;

        [SerializeField] private PlayerController _playerController;

        [SerializeField] private PlayerSFXPlayer _playerSFXPlayer;

        #endregion

        #region Methods

        private void CheckToDoDashSlash()
        {
            switch (_inputManager.IsDashSlashPerformed())
            {
                case true:
                    _canDashSlash = true;
                    PerformDashSlash();
                    break;
                case false:
                    _canDashSlash = false;
                    break;
            }
        }

        private void PerformDashSlash()
        {
            if (GameToggler.instance.GameStarted)
            {
                if (_canDashSlash && _dashSlashEnabler.GetDashSlashAmount() > 0)
                {
                    Debug.Log("Performed Dash Slash!");
                    _rigidBody.AddForce(_swordMover.GetCurrentDirectionRotatingTo() * _dashSlashSpeed, ForceMode2D.Impulse);
                    _playerSFXPlayer.PlaySoundEffect(1, transform.position, 1, Random.Range(0.8f, 1.2f));
                    _dashSlashEnabler.RemoveDashSlash();
                    _currentlyDashSlashing = true;
                }
            }
        }

        private void DamageWithDashSlash()
        {
            // If we have collided with an enemy, damage that enemy
            if (_currentlyDashSlashing)
            {
                if (_enemyDetector.GetHasHitEnemyValue() && _enemyDetector.GetEnemyToAttack())
                {
                    _enemyDetector.GetEnemyToAttack().DecrementHealth(50);

                    // Check if our velocity has at elast returned to the regualr walking pace before ending the Dash Slash
                    if (_rigidBody.linearVelocity.x <= _playerController.GetPlayerMovementSpeed() || _rigidBody.linearVelocity.x >= -_playerController.GetPlayerMovementSpeed() && _rigidBody.linearVelocity.y <= _playerController.GetPlayerMovementSpeed() || _rigidBody.linearVelocity.y >= -_playerController.GetPlayerMovementSpeed())
                    {
                        _currentlyDashSlashing = false;
                    }
                }
            }
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Update()
        {
            CheckToDoDashSlash();

            DamageWithDashSlash();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //PerformDashSlash();
            //Debug.Log(_rigidBody.linearVelocity);
        }

        #endregion
    }
}