using UnityEngine;

namespace GJAM3.Sword
{
    public class DashSlashEnabler : MonoBehaviour
    {
        public static DashSlashEnabler instance;

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

        [SerializeField] private int _dashSlashAmount;

        [SerializeField] private DashSlashHUDUpdater _dashSlashHUDUpdater;

        #endregion

        #region Methods

        public void AddDashSlash()
        {
            _dashSlashAmount++;
            _dashSlashHUDUpdater.UpdateDashSlashHUDText();
        }

        public void RemoveDashSlash()
        {
            _dashSlashAmount--;
            _dashSlashHUDUpdater.UpdateDashSlashHUDText();
        }

        public int GetDashSlashAmount()
        {
            return _dashSlashAmount;
        }

        #endregion
    }
}