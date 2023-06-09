﻿using System.Threading;
using NativeWebSocket;
using UnityEngine;

namespace GameCore.APIConnect
{
    public class OdometerAPI : MonoBehaviour
    {
        [SerializeField] private TextAsset _config;

        public delegate void OdometerHandler(float newValue);
        public event OdometerHandler OnNewOdometerEvent;

        public delegate void Handler();

        public event Handler ConnectionEvent;
        public event Handler DisconnectionEvent;
        
        private WebSocket _websocket;
        async void Start()
        {
            _websocket = new WebSocket(GetURLFromConfig());

            _websocket.OnOpen += () =>
            {
                Debug.Log("Connection open!");
                ConnectionEvent?.Invoke();
            };

            _websocket.OnError += (e) =>
            {
                Debug.Log("Error! " + e);
            };

            _websocket.OnClose += (e) =>
            {
                Debug.Log("Connection closed!");
                DisconnectionEvent?.Invoke();
            };

            _websocket.OnMessage += (bytes) =>
            {
                var message = System.Text.Encoding.UTF8.GetString(bytes);
                var value = JsonUtility.FromJson<OdometerResponse>(message).odometer;
                OnNewOdometerEvent?.Invoke(value);
                Debug.Log("OnMessage! " + message);
            };
            
            InvokeRepeating("SendWebSocketMessage", 0.0f, 10f);

            await _websocket.Connect();
        }

        void Update()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            _websocket.DispatchMessageQueue();
#endif
        }

        async void SendWebSocketMessage()
        {
            if (_websocket.State == WebSocketState.Connecting)
            {
                Thread.Sleep(1000);
            }
            if (_websocket.State == WebSocketState.Open)
            {
                await _websocket.SendText("{\"operation\":\"getCurrentOdometer\"}");
            }
            else
            {
                if (_websocket.State == WebSocketState.Closed)
                {
                    await _websocket.Connect();
                }
            }
        }

        private async void OnApplicationQuit()
        {
            await _websocket.Close();
        }

        private string GetURLFromConfig()
        {
            var text = _config.text.Replace("\r", "");
            var strings = text.Split('\n');
            return $"ws://{strings[0].Split(' ')[1]}:{strings[1].Split(' ')[1]}/ws";
        }

        private class OdometerResponse
        {
            public string operation;
            public float odometer;
        }
    }
}