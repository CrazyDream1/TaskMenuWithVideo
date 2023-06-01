using UnityEngine;

namespace GameCore.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NenSettings", menuName = "Settings", order = 51)]
    public class Settings : ScriptableObject
    {
        [SerializeField] public bool IsMusicEnabled;
        [SerializeField] public bool IsSoundEnabled;
        [SerializeField] [Range(0, 1f)] public float MusicAndSoundVolume = 1;
        [SerializeField] public string StreamUrl;
    }
}