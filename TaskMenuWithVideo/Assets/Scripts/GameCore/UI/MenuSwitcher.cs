using UnityEngine;

namespace GameCore.UI
{
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject _main;
        [SerializeField] private GameObject _settings;

        public void ToMenu()
        {
            _main.SetActive(true);
            _settings.SetActive(false);
        }

        public void ToSettings()
        {
            _main.SetActive(false);
            _settings.SetActive(true);
        }
    }
}