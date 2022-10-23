using Manager;
using UI.Manual;
using UnityEngine;

namespace UI.Title
{
    public class TitleManualButton : UIButton
    {
        private WindowManager _windowManager;

        protected override void Start()
        {
            GameObject.FindWithTag("WindowManager").TryGetComponent(out _windowManager);
            
            base.Start();
        }

        protected override async void OnClick()
        {
            await _windowManager.OpenWindow<ManualWindow>();
        }
    }
}