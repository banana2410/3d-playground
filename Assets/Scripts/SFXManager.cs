using System;
using UnityEngine;
using UnityEngine.Pool;

namespace DefaultNamespace
{
    public class SFXManager : MonoBehaviour
    {
        public static SFXManager Instance;
        private ObjectPool<SFXSource> pool;
        private AudioDatabase audioDatabase;
        [SerializeField] private SFXSource sourcePrefab;
        
        private void Awake()
        {
            Initialize();

            pool = new ObjectPool<SFXSource>(OnObjectCreated, OnObjectGet, OnObjectRelease,OnObjectDestroyed,
                defaultCapacity: 30);
            audioDatabase = Resources.Load<AudioDatabase>("AudioDatabase");
        }

        private void OnObjectDestroyed(SFXSource obj)
        {
            Debug.Log("Pool is full, cant return anymore - Destroying Gameobject");
            Destroy(obj.gameObject);
        }

        public void PlaySound(string id)
        {
            if (!audioDatabase.TryGetAudioClip(id, out var audioClip))
                throw new Exception($"Can't find requested audio clip with id {id} in AudioClip database");
            var audioSource = pool.Get();
            audioSource.PlaySound(audioClip, pool);
        }

        void Initialize()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); 
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void OnObjectRelease(SFXSource obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void OnObjectGet(SFXSource obj)
        {
            obj.gameObject.SetActive(true);
        }

        private SFXSource OnObjectCreated()
        {
            var sfxSource = Instantiate(sourcePrefab);
            return sfxSource;
        }
    }
}