using UnityEngine;
using GJAM3.Player;

namespace GJAM3.Sword
{
    public class SwordMover : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private bool _swordIsInRange;

        [Header("Objects")]

        [SerializeField] private GameObject _swordSprite;

        [SerializeField] private GameObject _playerObject;

        [Header("Components")]

        [SerializeField] private Camera _camera;

        [SerializeField] private Collider2D _swordRange;

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

            // InputManager has values returned by input system
            Vector2 readValue = _inputManager.GetSwordMovementValue();

            // From memory, the tutorial I got the idea to add the camera's z pos to here said that this would give the most accurate results
            Vector3 screenPosition = _camera.ScreenToWorldPoint(new Vector3(readValue.x, readValue.y, _camera.transform.position.z));

            // We want to roatte the empty obj that the sword is attached to in the direction of the world space position we just got.

            // Normalized for smoother movement according to tutorial
            Vector3 directionToRotateTo = (screenPosition - transform.position).normalized;
            directionToRotateTo.z = 0;

            // No idea what Atan2 is doing here to get the angle our sword points at. WIll need to find out later
            float angle = Mathf.Atan2(directionToRotateTo.y, directionToRotateTo.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            Vector2 directionToMoveTo;

            if (_swordRange.bounds.Contains(transform.position) && Vector2.Distance(transform.position, _playerObject.transform.position) < 1f)
            {
                directionToMoveTo = Vector2.MoveTowards(transform.position, screenPosition, 10 * Time.deltaTime);
                transform.position = directionToMoveTo;
            }
            else if (Vector2.Distance(transform.position, _playerObject.transform.position) > 1f)
            {
                directionToMoveTo = Vector2.MoveTowards(transform.position, _playerObject.transform.position, 10 * Time.deltaTime);
                transform.position = directionToMoveTo;
            }

        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            MoveSword();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("SwordRange"))
            {
                _swordIsInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("SwordRange"))
            {
                _swordIsInRange = false;
            }
        }

        #endregion
    }
}