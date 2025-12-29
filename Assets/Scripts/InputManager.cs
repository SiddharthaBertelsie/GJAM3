using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Variables

    [Header("Data")]

    [Tooltip("The value of the stick is placed into here to be used by the player character in game")]
    public Vector3 playerMovementValue;

    #endregion

    /// <summary>
    /// Here, we obtain the movement value form the stick and set it to the variable,
    /// </summary>
    /// <param name="context"></param>
    public void Movement(InputAction.CallbackContext context)
    {
        // We set a local variable to ensure each time called, the input is updated, and we need to define it so we can use its values in the Vector 3 value below.
        Vector2 movement = context.ReadValue<Vector2>();

        // We use RigidBody.MovePosition to ensure collisions are accounted for. the y values is used in the z due to the OG value being Vector2
        playerMovementValue = new Vector3(movement.x, 0, movement.y); 
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
}