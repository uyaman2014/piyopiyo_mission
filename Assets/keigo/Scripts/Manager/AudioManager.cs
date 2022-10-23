using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Manager
{
    /// <summary>
    ///     音楽の再生を管理する
    /// </summary>
    /// <remarks>AudioMixerのほうがよさげだったのでとりあえずこれは非推奨です。AudioMixerManagerを使ってください</remarks>
    [RequireComponent(typeof(AudioSource))]
    [Obsolete]
    public class AudioManager : MonoBehaviour
    {
        private readonly Dictionary<int, Cache<AudioClip>> _clipCache = new();

        private AudioSource _source;
        

        private void Start()
        {
            TryGetComponent(out _source);
        }

        private async UniTask<AudioClip> LoadAudioAsset(string assetName)
        {
            return (AudioClip)await Resources.LoadAsync<AudioClip>(assetName);
        }

        /// <summary>
        /// 効果音を再生
        /// </summary>
        /// <param name="assetName"></param>
        public async UniTask PlaySEOneShot(string assetName)
        {
            _source.PlayOneShot(await GetOrCreateCache(assetName));
        }

        public async UniTask PlayBGM(string assetName)
        {
            
        }

        private void EvaluateCache()
        {
            var drop = from cache in _clipCache where cache.Value.IsDrop() select cache;
            foreach (var (key, value) in drop.ToArray())
            {
                _clipCache.Remove(key);
            }
        }

        private async UniTask<AudioClip> GetOrCreateCache(string assetName)
        {
            if (_clipCache.TryGetValue(assetName.GetHashCode(), out var cached))
            {
                return cached.CachedObj;
            }

            var clip = new Cache<AudioClip>(await LoadAudioAsset(assetName));
            _clipCache[assetName.GetHashCode()] = clip;
            return clip.CachedObj;
        }

        private class Cache<T>
        {
            private const float Threshold = 60;
            private readonly float _createdTime = Time.time;

            public readonly T CachedObj;

            public Cache(T cachedObj)
            {
                CachedObj = cachedObj;
            }

            /// <summary>
            ///     このキャッシュを破棄するか
            /// </summary>
            /// <returns></returns>
            public bool IsDrop()
            {
                return Time.time - _createdTime > Threshold;
            }
        }
    }
}