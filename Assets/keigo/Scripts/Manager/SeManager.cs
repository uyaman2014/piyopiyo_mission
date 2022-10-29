using System;
using System.Collections.Generic;
using System.Linq;
using keigo.Scripts.Common;
using UnityEngine;

namespace Manager
{
    /// <summary>
    ///     効果音マネージャー
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SeManager : MonoBehaviour
    {
        private AudioSource _source;
        private readonly Cache<string, AudioClip> _cache = new(Resources.Load<AudioClip>);

        public static SeManager Instance
        {
            get
            {
                GameObject.FindWithTag("SeManager").TryGetComponent(out SeManager manager);
                return manager;
            }
        }
        
        private void Start()
        {
            TryGetComponent(out _source);
        }

        public void PlayOneShot(string audioClip, float volumeScale)
        {
            _source.PlayOneShot(_cache.Get(audioClip), volumeScale);
        }

        public void PlayOneShot(AudioClip audioClip, float volumeScale)
        {
            _source.PlayOneShot(audioClip, volumeScale);
        }

        private class Cache<TKey, TValue>
        {
            private readonly Dictionary<TKey, CacheValue<TValue>> _cache = new();
            private readonly Func<TKey, TValue> _factory;

            public Cache(Func<TKey, TValue> factory)
            {
                _factory = factory;
            }

            public TValue Get(TKey key)
            {
                void Drop()
                {
                    foreach (var deleted in (from v in _cache where v.Value.IsDrop select v.Key).ToArray())
                        _cache.Remove(deleted);
                }

                if (_cache.TryGetValue(key, out var value))
                {
                    var v = value.Value;
                    Drop();
                    return v;
                }

                Drop();
                var created = new CacheValue<TValue>(_factory(key));
                _cache.Add(key, created);
                return created.Value;
            }
        }

        private class CacheValue<T>
        {
            private readonly T _value;
            private float _time;

            public CacheValue(T value)
            {
                _value = value;
                _time = Time.time;
            }

            public T Value
            {
                get
                {
                    _time = Time.time;
                    return _value;
                }
            }

            public bool IsDrop => Time.time - _time >= 60;
        }
    }
}