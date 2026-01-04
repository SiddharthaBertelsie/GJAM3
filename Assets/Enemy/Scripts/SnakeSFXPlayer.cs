using UnityEngine;

namespace GJAM3.Enemy
{
    public class SnakeSFXPlayer : SFXPlayer
    {
        #region Variables

        [SerializeField] private float _timeBetweenFootstepSFX;

        [SerializeField] private AudioSource _walkingSFXPlayer;

        #endregion

        #region Methods

        public void PlayWalkingSFX()
        {
            _timeBetweenFootstepSFX = 0;

            _walkingSFXPlayer.gameObject.SetActive(true);
            _walkingSFXPlayer.pitch = Random.Range(0.8f, 1.2f);
            _walkingSFXPlayer.Play();

            _timeBetweenFootstepSFX = 1;
        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            if (_walkingSFXPlayer.gameObject.activeSelf && _timeBetweenFootstepSFX > 0)
            {
                _timeBetweenFootstepSFX -= Time.deltaTime;

                if (_timeBetweenFootstepSFX <= 0)
                {
                    _walkingSFXPlayer.gameObject.SetActive(false);
                }
            }
        }

        #endregion
    }
}