using GJAM3.Sword;
using UnityEngine;

namespace GJAM3.Enemy
{
    public class FireballShooter : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private float _fireballSpeed;

        [SerializeField] private bool _hasFiredFireball;

        [Header("Components")]

        [SerializeField] private Rigidbody2D _fireball;

        [SerializeField] private Transform _fireballFirePoint;

        [SerializeField] private Transform _playerTransform;

        [Header("Scripts")]

        [SerializeField] private SwordMover _swordMover;

        [SerializeField] private GoblinSFXPlayer _goblinSFXPlayer;

        #endregion

        #region Methods

        public void ShootFireball()
        {
            //float angle = Mathf.Atan2(_swordMover.GetCurrentDirectionRotatingTo().y, _swordMover.GetCurrentDirectionRotatingTo().x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Rigidbody2D currentFireball = Instantiate(_fireball.gameObject, _fireballFirePoint.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            _goblinSFXPlayer.PlaySoundEffect(0, _fireballFirePoint.position, 1, 1);

            currentFireball.AddForce((_playerTransform.position - transform.position) * _fireballSpeed, ForceMode2D.Impulse);
            //_fireball.linearVelocity = (_playerTransform.position - transform.position) * _fireballSpeed;
            
            //Vector2 currentPlayerPos = _playerTransform.position - transform.position;
            //_fireball.MovePosition(currentPlayerPos * _fireballSpeed * Time.deltaTime);

            _hasFiredFireball = true;
        }

        public bool GetHasFiredFireball()
        {
            return _hasFiredFireball;
        }

        private void InitializeVariables()
        {
            _playerTransform = GlobalMethods.instance.GetPlayerTransform();
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitializeVariables();
        }

        private void FixedUpdate()
        {

        }

        #endregion
    }
}