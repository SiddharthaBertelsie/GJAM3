using UnityEngine;

namespace GJAM3
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager instance;

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

        [Header("Start Menu")]

        [SerializeField] private GameObject _startMenu;

        [Header("Exit Menu")]

        [SerializeField] private GameObject _gameOverMenu;

        #endregion

        #region Methods

        public void ToggleStartMenu(bool value)
        {
            _startMenu.SetActive(value);
        }

        public void ToggleGameOverMenu(bool value)
        {
            _gameOverMenu.SetActive(value);
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            ToggleStartMenu(true);
            ToggleGameOverMenu(false);
        }

        #endregion
    }
}