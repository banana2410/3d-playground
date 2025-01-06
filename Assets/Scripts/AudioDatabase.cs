using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "AudioDatabase", menuName = "Scriptable Objects/Audio/AudioDatabase")]
    public class AudioDatabase : ScriptableObject
    {
        public List<AudioClipObject> AudioClips;
        private Dictionary<string, AudioClipObject> audioClipDictionary = new();

        public bool TryGetAudioClip(string id, out AudioClipObject audioClipObject)
        {
            if (audioClipDictionary.Count == 0)
            {
                foreach (var audioclip in AudioClips)
                {
                    audioClipDictionary[audioclip.id] = audioclip;
                }
            }

            var success = audioClipDictionary.TryGetValue(id, out audioClipObject);
            return success;
        }
    }
}