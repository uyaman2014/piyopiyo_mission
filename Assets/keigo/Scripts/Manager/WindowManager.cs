using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using DG.Tweening;
using UI.Window;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Manager
{
    /// <summary>
    ///     同じシーン内でウィンドウを開く
    /// </summary>
    public class WindowManager : MonoBehaviour
    {
        [SerializeField] private Image maskImage;

        private BaseWindow _currentWindow;
        private float _maskImageInitAlpha;

        private void Awake()
        {
            maskImage.CrossFadeAlpha(0, 0, false);
            maskImage.gameObject.SetActive(false);
            _maskImageInitAlpha = maskImage.color.a;
        }

        /// <summary>
        ///     指定されたウィンドウをリソースから読み込んで表示
        /// </summary>
        public async UniTask OpenWindow<T>() where T : BaseWindow
        {
            // TODO: 初回は何故か暗くならない

            var resource = await ResourceAttribute.LoadResourceInAttribute<T>();
            _currentWindow = Instantiate(resource);
            maskImage.gameObject.SetActive(true);
            maskImage.DOFade(_maskImageInitAlpha, 0.2f);
            _currentWindow.Open();

            UniTask.Create(async () =>
            {
                await _currentWindow.OnDestroyAsync();
                _currentWindow = null;
                maskImage.DOFade(0, 0.2f).OnComplete(() => maskImage.gameObject.SetActive(false));
            });
        }

        /// <summary>
        ///     現在開いているウィンドウを閉じる
        /// </summary>
        public void CloseWindow()
        {
            _currentWindow.Close();
            Destroy(_currentWindow.gameObject);
            _currentWindow = null;
            maskImage.DOFade(0, 0.2f).OnComplete(() => maskImage.gameObject.SetActive(false));
        }
    }

    public class ResourceAttribute : Attribute
    {
        private readonly string _resourceName;

        public ResourceAttribute(string resourceName)
        {
            _resourceName = resourceName;
        }

        private async UniTask<T> LoadResource<T>() where T : Object
        {
            return (T)await Resources.LoadAsync<T>(_resourceName);
        }

        public static UniTask<T> LoadResourceInAttribute<T>() where T : Component
        {
            var attribute = GetCustomAttribute(typeof(T), typeof(ResourceAttribute)) as ResourceAttribute;
            return attribute!.LoadResource<T>();
        }
    }
}