using System;
using DG.Tweening;
using GameCore.APIConnect;
using TMPro;
using UnityEngine;

namespace GameCore.UI
{
    public class OdometerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _odometer;
        [SerializeField] private OdometerAPI _odometerAPI;
        [SerializeField] private float _duration = 1.5f;
        
        private float _oldValue = 0;
        
        private void Start()
        {
            _odometerAPI.OnNewOdometerEvent += UpdateOdometr;
        }

        private void UpdateOdometr(float newValue)
        {
            if (_oldValue != newValue)
            {
                DOTween.To(() => _oldValue, x => _oldValue = x, newValue, _duration)
                    .OnUpdate(() => { _odometer.text = _oldValue.ToString(); });
            }
        }
    }
}