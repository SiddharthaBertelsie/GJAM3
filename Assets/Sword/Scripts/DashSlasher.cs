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

        [Header("Components")]

        [SerializeField] private Rigidbody2D _rigidBody;

        [Header("Scripts")]

        [SerializeField] private InputManager _inputManager;

        [SerializeField] private EnemyDetector _enemyDetector;

        [SerializeField] private SwordMover _swordMover;

        [SerializeField] private DashSlashEnabler _dashSlashEnabler;

        [SerializeField] private DashSlashHUDUpdater _dashSlashHUDUpdater;

        #endregion

        #region Methods

        private void PerformDashSlash()
        {
            if (GameToggler.instance.GameStarted)
            {
                if (_canDashSlash && _dashSlashEnabler.GetDashSlashAmount() > 0)
                {
                    Debug.Log("Performed Dash Slash!");
                    _rigidBody.AddForce(_swordMover.GetCurrentDirectionRotatingTo() * _dashSlashSpeed, ForceMode2D.Impulse);
                    _dashSlashEnabler.RemoveDashSlash();
                }
            }
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Update()
        {
            switch (_inputManager.IsDashSlashInProgress())
            {
                case true:
                    _canDashSlash = true;
                    break;
                case false:
                    _canDashSlash = false;
                    break;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            PerformDashSlash();
        }

        #endregion
    }
}