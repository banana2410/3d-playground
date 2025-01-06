using System;
using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class SFXSource : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        private float time;
        private float clipDuration;
        private ObjectPool<SFXSource> objectPool;

        public void PlaySound(AudioClipObject audioClipObject, ObjectPool<SFXSource> objectPool)
        {
            this.objectPool = objectPool;
            var audioClip = audioClipObject.AudioClip;
            clipDuration = audioClip.length;
            source.clip = audioClip;
            source.volume = audioClipObject.Volume;
            source.Play();
        }

        private void Update()
        {
            time += Time.deltaTime;
            if (time >= clipDuration) ReturnToPool();
        }

        private void ReturnToPool()
        {
            time = 0f;
            objectPool.Release(this);
        }
    }
}