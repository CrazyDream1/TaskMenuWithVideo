using System;
using DG.Tweening;
using GameCore.APIConnect;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.UI
{
    public class ConnectionIndicators : MonoBehaviour
    {
        [SerializeField] private RawImage _image;
        [SerializeField] private TMP_Text _textConnection;
        [SerializeField] private TMP_Text _textDisconnection;
        [SerializeField] private OdometerAPI _odometerAPI;

        private void Start()
        {
            _odometerAPI.ConnectionEvent += Connected;
            _odometerAPI.DisconnectionEvent += Disconnected;
        }

        public void Connected()
        {
            _image.color = Color.green;
            var sequence = DOTween.Sequence()
                .AppendCallback(() => _textConnection.gameObject.SetActive(true))
                .AppendInterval(1f)
                .AppendCallback(() => _textConnection.gameObject.SetActive(false));
        }

        public void Disconnected()
        {
            _image.color = Color.red;
            var sequence = DOTween.Sequence()
                .AppendCallback(() => _textDisconnection.gameObject.SetActive(true))
                .AppendInterval(1f)
                .AppendCallback(() => _textDisconnection.gameObject.SetActive(false));
        }
    }
}