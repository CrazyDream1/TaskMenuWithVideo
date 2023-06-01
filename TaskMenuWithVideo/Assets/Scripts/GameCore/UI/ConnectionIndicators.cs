using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.UI
{
    public class ConnectionIndicators : MonoBehaviour
    {
        [SerializeField] private RawImage _image;
        [SerializeField] private TMP_Text _textConnection;
        [SerializeField] private TMP_Text _textDisconnected;

        public void Connected()
        {
            _image.color = Color.green;
            //TODO add text fade
        }

        public void Disconnected()
        {
            _image.color = Color.red;
            
        }
    }
}