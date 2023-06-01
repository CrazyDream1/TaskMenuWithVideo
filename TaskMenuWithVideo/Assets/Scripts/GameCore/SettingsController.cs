using GameCore.ScriptableObjects;
using UnityEngine;

namespace GameCore
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] private Settings _settings;
        
        public bool IsMusicEnabled => _settings.IsMusicEnabled;
        public bool IsSoundEnabled => _settings.IsSoundEnabled;
        public float Volume => _settings.MusicAndSoundVolume;
        public string StreamUrl => _settings.StreamUrl;
        
        public void ChangeMusicState()
        {
            _settings.IsMusicEnabled = !_settings.IsMusicEnabled;
            OnMusicChangedEvent?.Invoke();
        }
        
        public void ChangeSoundState()
        {
            _settings.IsSoundEnabled = !_settings.IsMusicEnabled;
            OnSoundChangedEvent?.Invoke();
        }

        public void ChangeVolume(float volume)
        {
            _settings.MusicAndSoundVolume = volume;
            OnVolumeChangedEvent?.Invoke(volume);
        }
        
        public delegate void OnChangeHandler();
        public event OnChangeHandler OnMusicChangedEvent;
        public event OnChangeHandler OnSoundChangedEvent;

        public delegate void OnVolumeChangeHandler(float newVolume);
        public event OnVolumeChangeHandler OnVolumeChangedEvent;
    }
}