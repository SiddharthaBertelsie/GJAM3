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

        [SerializeField] private GameObject _exitMenu;

        #endregion

        #region Methods

        public void ToggleStartMenu(bool value)
        {
            _startMenu.SetActive(value);
        }

        public void ToggleExitMenu(bool value)
        {
            _exitMenu.SetActive(value);
        }

        #endregion
    }
}