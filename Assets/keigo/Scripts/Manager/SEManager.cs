using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Manager
{
    /// <summary>
    ///     音楽の再生を管理する
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SeManager : MonoBehaviour
    {
        private readonly Dictionary<int, Cache<AudioClip>> _clipCache = new();

        private AudioSource _source;


        private void Start()
        {
            TryGetComponent(out _source);
        }

        private static async UniTask<AudioClip> LoadAudioAsset(string assetName)
        {
            return (AudioClip)await Resources.LoadAsync<AudioClip>(assetName);
        }

        /// <summary>
        ///     効果音を再生
        /// </summary>
        /// <param name="assetName"></param>
        public async UniTask PlaySEOneShot(string assetName)
        {
            _source.PlayOneShot(await GetOrCreateCache(assetName));
            EvaluateCache();
        }

        private void EvaluateCache()
        {
            var drop = from cache in _clipCache where cache.Value.IsDrop() select cache;
            foreach (var (key, _) in drop.ToArray()) _clipCache.Remove(key);
        }

        private async UniTask<AudioClip> GetOrCreateCache(string assetName)
        {
            if (_clipCache.TryGetValue(assetName.GetHashCode(), out var cached)) return cached.CachedObj;

            var clip = new Cache<AudioClip>(await LoadAudioAsset(assetName));
            _clipCache[assetName.GetHashCode()] = clip;
            return clip.CachedObj;
        }

        private class Cache<T>
        {
            private const float Threshold = 60;
            private float _createdTime = Time.time;

            private readonly T _cachedObj;

            public T CachedObj
            {
                get
                {
                    _createdTime = Time.time;
                    return _cachedObj;
                }
            }

            public Cache(T cachedObj)
            {
                _cachedObj = cachedObj;
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