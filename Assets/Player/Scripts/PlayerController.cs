using GJAM3.Sword;
using UnityEngine;

namespace GJAM3.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("Number determines how much the movement value from control stick will be multiplied by (Speed)")]
        public float playerSpeed;

        [Tooltip("Number determines how fast the player turns when the control stick is mvoed in a direction. This needs to be set very high to work")]
        public float playerRotationSpeed;

        private bool isSpecialMoveActive;

        [Header("Components")]

        [Tooltip("The rigid body of our player character, used for movement and collisions")]
        [SerializeField] private Rigidbody2D rigidBody;

        [Header("Script")]

        [SerializeField] private InputManager inputManager;

        [SerializeField] private DashSlasher _dashSlasher;

        [SerializeField] private PlayerSFXPlayer _playerSFXPlayer;

        #endregion

        #region Methods

        /// <summary>
        /// Here, we handle the players movement. They'll move based on the input given from control stick, and playerSpeed's value
        /// </summary>
        private void Movement()
        {
            if (GameToggler.instance.GameStarted && !isSpecialMoveActive)
            {
                // This code here is responsible for turning the player in the direction of the gamepad stick
                if (inputManager.playerMovementValue != Vector2.zero) // When the stick is in the dead zone, we'll still keep the same rotation before hand.
                {
                    _playerSFXPlayer.SetPlayFootstepsSFX(true);
                    rigidBody.linearVelocity = inputManager.playerMovementValue * Time.fixedDeltaTime * playerSpeed;
                }
                else
                {
                    _playerSFXPlayer.SetPlayFootstepsSFX(false);
                    rigidBody.linearVelocity = Vector2.zero;
                }
            }
        }

        public float GetPlayerMovementSpeed()
        {
            return playerSpeed;
        }

        #endregion

        #region Unity Methods

        // We call the method in fixe duodate, due to using a Rigidbidy to detetc for collisions
        void FixedUpdate()
        {
            Movement();
        }

        private void Update()
        {
            if (inputManager.IsDashSlashInProgress())
            {
                isSpecialMoveActive = true;
            }
            else
            {
                isSpecialMoveActive= false;
            }
        }

        #endregion
    }
}