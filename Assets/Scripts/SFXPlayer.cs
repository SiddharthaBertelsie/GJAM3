using UnityEngine;

namespace GJAM3
{
    public class SFXPlayer : MonoBehaviour
    {
        [SerializeField] protected AudioClip[] _soundEffects;

        [SerializeField] protected GameObject _instantiatedAudioSource;

        public virtual void PlaySoundEffect(int soundEffectIndex, Vector3 pos, float volume, float pitch)
        {
            // Ransaked code
            AudioSource aSource = Instantiate(_instantiatedAudioSource).GetComponent<AudioSource>();
            aSource.gameObject.transform.position = pos;
            aSource.clip = _soundEffects[soundEffectIndex];
            aSource.volume = volume;
            aSource.pitch = pitch;

            aSource.PlayOneShot(_soundEffects[soundEffectIndex]);
            Destroy(aSource.gameObject, _soundEffects[soundEffectIndex].length);
        }
    }
}