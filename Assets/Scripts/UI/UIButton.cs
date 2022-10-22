using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class UIButton : MonoBehaviour
    {
        private Button _button;

        protected virtual void Start()
        {
            TryGetComponent(out _button);
            _button.onClick.AddListener(OnClick);
        }

        protected abstract void OnClick();
    }
}