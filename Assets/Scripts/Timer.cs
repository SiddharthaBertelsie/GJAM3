using GJAM3.Enemy;
using TMPro;
using UnityEngine;

namespace GJAM3.Timer
{
    public class Timer : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _currentElapsedTime;

        [SerializeField] private int _elapsedTime;

        [SerializeField] private TextMeshProUGUI _timerText;

        [SerializeField] private EnemySpawner _enemySpawner;

        #endregion

        #region Methods

        private void RunTimer()
        {
            if (GameToggler.instance.GameStarted)
            {
                _currentElapsedTime += Time.deltaTime;

                if (_currentElapsedTime >= 1)
                {
                    _elapsedTime += (int)_currentElapsedTime;
                    Mathf.RoundToInt(_elapsedTime);
                    _timerText.text = "Time: " + _elapsedTime;
                    _currentElapsedTime = 0;
                    _enemySpawner.CheckToDecreaseSpawnCooldown();
                }
            }
        }

        private void InitializeVariables()
        {
            _currentElapsedTime = 0;
            _elapsedTime = 0;
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitializeVariables();
        }

        // Update is called once per frame
        void Update()
        {
            RunTimer();
        }

        #endregion
    }
}