using GJAM3;
using UnityEngine;

namespace GJAM3.Enemy
{
    public class FireballHitDetector : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _attackDamage;

        [SerializeField] private EnemyHealthManager _enemyToAttack;

        [SerializeField] private GoblinSFXPlayer _goblinSFXPlayer;

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                GlobalMethods.instance.DamagePlayer(_attackDamage);
                _goblinSFXPlayer.PlaySoundEffect(1, transform.position, 1, 1);
                Destroy(gameObject);
            }
            else if (collision.CompareTag("Enemy"))
            {
                _enemyToAttack = collision.GetComponent<EnemyHealthManager>();
                _enemyToAttack.DecrementHealth(_attackDamage);
                _goblinSFXPlayer.PlaySoundEffect(1, transform.position, 1, 1);
                Destroy(gameObject);
            }
        }

        #endregion
    }
}