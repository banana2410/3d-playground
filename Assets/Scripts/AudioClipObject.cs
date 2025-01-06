using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Audio Clip Object", menuName = "Scriptable Objects/Audio/AudioClip")]
    public class AudioClipObject : ScriptableObject
    {
        public string id;
        public AudioClip AudioClip;
        [Range(0f,1f)]
        public float Volume;
    }
}