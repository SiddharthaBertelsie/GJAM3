using UnityEngine;
using GJAM3.Player;

namespace GJAM3.Sword
{
    public class DashSlasher : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private float _dashSlashSpeed;

        [Header("Components")]

        [SerializeField] private Rigidbody2D _rigidBody;

        [Header("Scripts")]

        [SerializeField] private InputManager _inputManager;

        [SerializeField] private EnemyDetector _enemyDetector;

        [SerializeField] private SwordMover _swordMover;

        #endregion

        #region Methods

        private void PerformDashSlash()
        {
            if (GameToggler.instance.GameStarted)
            {
                if (_inputManager.IsDashSlashPerformed())
                {
                    Debug.Log("Performed Dash Slash!");
                    _rigidBody.AddForce(Vector2.down * _dashSlashSpeed, ForceMode2D.Impulse);
                }
            }
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            PerformDashSlash();
        }

        #endregion
    }
}