using UnityEngine;

namespace GJAM3.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _spawnCooldownTime;

        private float _timeToWait;

        [SerializeField] private GameObject[] _enemiesToSpawn;

        [SerializeField] private Transform[] _enemySpawnLocations;

        #endregion

        #region Methods

        public void SpawnEnemies()
        {
            if (GameToggler.instance.GameStarted)
            {
                if (_timeToWait <= 0)
                {
                    // >= 5: Snake
                    // >= 2: Stronger enemy
                    // <= 1: Strongest enemy
                    int enemyToSpawn = Random.Range(1, 10);
                    // 12 locations to possibly spawn at
                    int locationToSpawn = Random.Range(0, 11);

                    switch (enemyToSpawn)
                    {
                        case >= 5:
                            Instantiate(_enemiesToSpawn[0], _enemySpawnLocations[locationToSpawn].position, Quaternion.identity);
                            _timeToWait += _spawnCooldownTime;
                            break;
                        case >= 2:
                            break;
                        case <= 1:
                            break;
                    }
                }
            }
        }

        private void SpawnCooldown()
        {
            if (_timeToWait > 0)
            {
                _timeToWait -= Time.deltaTime;
            }
        }

        private void InitializeVariables()
        {
            _timeToWait = 0;
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            InitializeVariables();
        }

        private void Update()
        {
            SpawnEnemies();
            SpawnCooldown();
        }

        #endregion
    }
}