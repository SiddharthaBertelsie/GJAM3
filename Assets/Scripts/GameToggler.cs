using UnityEngine;
using UnityEngine.SceneManagement;

namespace GJAM3
{
    /// <summary>
    /// Handles starting and ending the game
    /// </summary>
    public class GameToggler : MonoBehaviour
    {
        public static GameToggler instance;

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

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        /// <summary>
        /// Remove this if WebGl can be done
        /// </summary>
        public void ExitGame()
        {
            Application.Quit();
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