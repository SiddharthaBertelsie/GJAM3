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

        [Header("Components")]

        [Tooltip("The rigid body of our player character, used for movement and collisions")]
        [SerializeField] private Rigidbody2D rigidBody;

        [Header("Script")]

        [SerializeField] private InputManager inputManager;

        #endregion

        #region Methods

        /// <summary>
        /// Here, we handle the players movement. They'll move based on the input given from control stick, and playerSpeed's value
        /// </summary>
        private void Movement()
        {
            // This code here is responsible for turning the player in the direction of the gamepad stick
            if (inputManager.playerMovementValue != Vector2.zero) // When the stick is in the dead zone, we'll still keep the same rotation before hand.
            {
                rigidBody.linearVelocity = inputManager.playerMovementValue * Time.fixedDeltaTime * playerSpeed;

                //Quaternion toRotation = Quaternion.LookRotation(inputManager.playerMovementValue, Vector2.zero); // Create a new rotation value, that's set to the current direction of the stick

                //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, playerRotationSpeed * Time.fixedDeltaTime); // Set the rotation to a rotation that turns to the prior specified rotation by a predefined speed
            }
            else
            {
                rigidBody.linearVelocity = Vector2.zero;
            }
        }

        #endregion

        #region Unity Methods

        // We call the method in fixe duodate, due to using a Rigidbidy to detetc for collisions
        void FixedUpdate()
        {
            Movement();
        }

        #endregion
    }
}