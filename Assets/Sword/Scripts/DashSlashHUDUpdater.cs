using TMPro;
using UnityEngine;

namespace GJAM3.Sword
{
    public class DashSlashHUDUpdater : MonoBehaviour
    {
        #region Variables

        [Header("Components")]

        [SerializeField] private TextMeshProUGUI _dashSlashAmountText;

        [Header("Scripts")]

        [SerializeField] private DashSlashEnabler _dashSlashEnabler;

        #endregion

        #region Methods

        public void UpdateDashSlashHUDText()
        {
            _dashSlashAmountText.text = "Dash Slash: " + _dashSlashEnabler.GetDashSlashAmount();
        }

        #endregion

        #region Unity Methods

        private void Start()
        {
            UpdateDashSlashHUDText();
        }

        #endregion
    }
}