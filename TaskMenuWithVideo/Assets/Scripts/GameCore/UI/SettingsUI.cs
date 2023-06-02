using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.UI
{
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] private SettingsController _settingsController;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private Toggle _music;
        [SerializeField] private Toggle _sound;

        [SerializeField] private TMP_Text _serverIp;
        [SerializeField] private TMP_Text _serverPort;
        [SerializeField] private TMP_Text _videoStreamUrl;

        [SerializeField] private TextAsset _config;
        
        private void Start()
        {
            _music.isOn = _settingsController.IsMusicEnabled;
            _sound.isOn = _settingsController.IsSoundEnabled;
            _volumeSlider.value = _settingsController.Volume;

            _videoStreamUrl.text = $"VideoUrl:{_settingsController.StreamUrl}";
            var text = _config.text.Replace("\r", "");
            var strings = text.Split('\n');
            _serverIp.text = $"ServerIp:{strings[0].Split(' ')[1]}";
            _serverPort.text = $"Port:{strings[1].Split(' ')[1]}";
        }

        public void OnMusicStateChange()
        {
            _settingsController.ChangeMusicState();
        }
        
        public void OnSoundStateChange()
        {
            _settingsController.ChangeSoundState();
        }
        
        public void OnVolumeChange()
        {
            _settingsController.ChangeVolume(_volumeSlider.value);
        }
        
    }
}