using UnityEngine;

namespace GJAM3.Player
{
    public class PlayerSFXPlayer : SFXPlayer
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private float _timeBetweenFootstepSFX;

        [SerializeField] private bool _playFootstepsSFX;

        [Header("Components")]

        [SerializeField] private AudioSource _footstepsSFXPlayer;

        #endregion

        #region Methods

        public void SetPlayFootstepsSFX(bool value)
        {
            _playFootstepsSFX = value;
        }

        public void PlayFootstepsSFX()
        {
            if (_timeBetweenFootstepSFX <= 0 && _playFootstepsSFX)
            {
                _footstepsSFXPlayer.Play();

                _timeBetweenFootstepSFX = 0.3f;
            }
        }

        private void Cooldown()
        {
            if (_timeBetweenFootstepSFX > 0)
            {
                _timeBetweenFootstepSFX -= Time.deltaTime;
            }
        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            PlayFootstepsSFX();
            Cooldown();
        }

        #endregion
    }
}