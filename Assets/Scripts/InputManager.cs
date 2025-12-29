using UnityEngine;
using UnityEngine.InputSystem;

namespace GJAM3.Player
{
    public class InputManager : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [Tooltip("The value of the stick is placed into here to be used by the player character in game")]
        public Vector2 playerMovementValue;

        #endregion

        /// <summary>
        /// Here, we obtain the movement value form the stick and set it to the variable,
        /// </summary>
        /// <param name="context"></param>
        public void Movement(InputAction.CallbackContext context)
        {
            // We set a local variable to ensure each time called, the input is updated, and we need to define it so we can use its values in the Vector 3 value below.
            Vector2 movement = context.ReadValue<Vector2>();

            // We use RigidBody.MovePosition to ensure collisions are accounted for.
            playerMovementValue = new Vector2(movement.x, movement.y);
            Debug.Log(playerMovementValue);
        }

        /// <summary>
        /// Here we call the method to grab or drop clothes when the south button is pressed
        /// </summary>
        /// <param name="context"></param>
        public void Interact(InputAction.CallbackContext context)
        {
            if (context.performed)
            {

            }
        }

        public Vector2 GetPlayerMovementValue()
        {
            return playerMovementValue;
        }
    }
}