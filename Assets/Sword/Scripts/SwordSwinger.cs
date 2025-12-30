using UnityEngine;
using GJAM3.Player;

namespace GJAM3.Sword
{
    public class SwordSwinger : MonoBehaviour
    {
        #region Variables

        [SerializeField] private bool _swordIsInRange;

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

            Vector3 screenPosition = _camera.ScreenToWorldPoint(new Vector3(readValue.x, readValue.y, _camera.transform.position.z));
            Debug.Log(screenPosition);

            // We want to roatte the empty obj that the sword is attached to in the direction of the world space position we just got.

            Vector3 directionToRotateTo = (screenPosition - transform.position).normalized;
            directionToRotateTo.z = 0;

            float angle = Mathf.Atan2(directionToRotateTo.y, directionToRotateTo.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            if (_swordIsInRange)
            {
                Vector3 directionToMoveTo = Vector3.MoveTowards(transform.position, screenPosition, 1);
                transform.position = directionToMoveTo * Time.deltaTime;
            }
            

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