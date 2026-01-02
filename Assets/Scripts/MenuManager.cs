using GJAM3.Player;
using System.Xml.Schema;
using TMPro;
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

        [Header("HUD")]

        [SerializeField] private GameObject _HUDMenu;

        [SerializeField] private TextMeshProUGUI _healthText;

        [Header("Scripts")]

        [SerializeField] private PlayerHealthManager _playerHealthManager;

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

        public void ToggleHUDMenu(bool value)
        {
            switch (value)
            {
                case true:
                    _HUDMenu.SetActive(true);
                    UpdateHUDHealthText(_playerHealthManager.GetHealth());
                    break;
                case false:
                    _HUDMenu.SetActive(false);
                    break;
            }
        }

        public void UpdateHUDHealthText(float value)
        {
            _healthText.text = "Health: " + value.ToString();
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            ToggleStartMenu(true);
            ToggleGameOverMenu(false);
            ToggleHUDMenu(false);
        }

        #endregion
    }
}