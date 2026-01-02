using GJAM3.Player;
using UnityEngine;

namespace GJAM3
{
    public class GlobalMethods : MonoBehaviour
    {
        public static GlobalMethods instance;

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

        [SerializeField] private PlayerHealthManager _playerHealthManager;

        #endregion

        public void DamagePlayer(float amount)
        {
            _playerHealthManager.DecrementHealth(amount);
        }
    }
}