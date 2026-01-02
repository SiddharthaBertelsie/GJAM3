using UnityEngine;

namespace GJAM3
{
    public class GameStarter : MonoBehaviour
    {
        public static GameStarter instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        #region Variables

        [SerializeField] private bool _gameStarted;

        #endregion

        #region Getter

        public bool GameStarted { get { return _gameStarted; } }

        #endregion

        #region Methods

        public void ToggleGameStarted(bool value)
        {
            switch (value)
            {
                case true:
                    Time.timeScale = 1;
                    break;
                case false:
                    Time.timeScale = 0;
                    break;
            }

            _gameStarted = value;
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            ToggleGameStarted(false);
        }

        #endregion
    }
}