using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Window
{
    /// <summary>
    ///     ウィンドウの基底クラス
    /// </summary>
    [RequireComponent(typeof(Image))]
    public abstract class BaseWindow : MonoBehaviour
    {
        private Image _container;

        private void Start()
        {
            TryGetComponent(out _container);

            _container.CrossFadeAlpha(0, 0, false);
            _container.gameObject.SetActive(false);
        }

        /// <summary>
        ///     ウィンドウ開く
        /// </summary>
        /// <returns></returns>
        public UniTask Open()
        {
            var taskSource = new UniTaskCompletionSource();

            _container.gameObject.SetActive(true);
            _container.DOFade(1, 0.1f).OnComplete(() => taskSource.TrySetResult());
            return taskSource.Task;
        }

        /// <summary>
        ///     ウィンドウ閉じる
        /// </summary>
        /// <returns></returns>
        public UniTask Close()
        {
            var taskSource = new UniTaskCompletionSource();

            _container.DOFade(0, 0.1f).OnComplete(() =>
            {
                _container.gameObject.SetActive(false);
                taskSource.TrySetResult();
            });
            return taskSource.Task;
        }
    }
}