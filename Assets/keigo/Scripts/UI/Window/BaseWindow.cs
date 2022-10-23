using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Window
{
    /// <summary>
    ///     ウィンドウの基底クラス
    /// </summary>
    public abstract class BaseWindow : MonoBehaviour
    {
        [SerializeField] private Button[] closeButtons;
        private WindowManager _windowManager;

#if UNITY_EDITOR
        private void Reset()
        {
            closeButtons = GetComponentsInChildren<Button>();
        }
#endif

        private void Start()
        {
            GameObject.FindWithTag("WindowManager").TryGetComponent(out _windowManager);

            foreach (var btn in closeButtons) btn.onClick.AddListener(_windowManager.CloseWindow);
        }

        /// <summary>
        ///     ウィンドウ開く
        /// </summary>
        /// <returns></returns>
        public void Open()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        ///     ウィンドウ閉じる
        /// </summary>
        /// <returns></returns>
        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}