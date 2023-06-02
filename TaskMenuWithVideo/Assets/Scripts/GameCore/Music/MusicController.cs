using UnityEngine;

namespace GameCore.Music
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicController : MonoBehaviour
    { 
        [SerializeField] private SettingsController _settingsController;

        private AudioSource _audio;
        
        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _settingsController.OnMusicChangedEvent += MusicStateChange;
            _settingsController.OnVolumeChangedEvent += VolumeChange;
            if (_settingsController.IsMusicEnabled)
            {
                _audio.Play();
            }
        }

        private void VolumeChange(float newVolume)
        {
            _audio.volume = newVolume;
        }

        private void MusicStateChange()
        {
            if (_audio.isPlaying)
            {
                _audio.Stop();
            }
            else
            {
                _audio.Play();
            }
        }
    }
}