using Manager;
using UnityEngine;

namespace UI.Game
{
    public class ReturnTitleButton : UIButton
    {
        private SceneTransManager _transManager;

        protected override void Start()
        {
            GameObject.FindGameObjectWithTag("TransManager").TryGetComponent(out _transManager);

            base.Start();
        }

        protected override async void OnClick()
        {
            await _transManager.TransitionScene("UI Title(keigo)");
        }
    }
}