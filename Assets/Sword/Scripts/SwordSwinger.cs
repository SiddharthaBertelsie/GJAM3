using UnityEngine;
using GJAM3.Player;

namespace GJAM3.Sword
{
    public class SwordSwinger : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _swordSprite;

        [SerializeField] private Camera _camera;

        [Header("Scripts")]

        [SerializeField] private InputManager _inputManager;

        [SerializeField] private SwordAnimationManager _swordAnimationManager;

        #endregion

        #region Methods

        private void MoveSword()
        {

            // Before running the code, we want to have a empty object that the sword sprite + collider is attachted to.
            // It will have an anim which swings in an arc.
            // The sword will be facing straight ahead on the object

            // The code:
            // We want to get the screen position of our mouse, and then convert it to a Vector2 world space position

            Vector2 readValue = _inputManager.GetSwordMovementValue();

            Vector2 screenPosition = _camera.ScreenToWorldPoint(readValue);
            Debug.Log(screenPosition);

            // We want to roatte the empty obj that the sword is attached to in the direction of the world space position we just got.

            Vector3 directionToRotateTo = Vector3.RotateTowards(transform.forward, screenPosition, 10 * Time.deltaTime, 0);

            transform.rotation = Quaternion.LookRotation(directionToRotateTo);

            // We want to enable the sword, before playing the animation

            _swordSprite.SetActive(true);

            // The sword should disappear after the animation is done.

        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            MoveSword();
        }

        #endregion
    }
}