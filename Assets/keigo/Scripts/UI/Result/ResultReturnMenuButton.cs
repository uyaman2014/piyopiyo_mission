using Manager;
using UnityEngine;

namespace UI.Result
{
    public class ResultReturnMenuButton : UIButton
    {
        [SerializeField] private string nextScene = "UI Title(keigo)";

        private SceneTransManager _transManager;

        protected override void Start()
        {
            GameObject.FindWithTag("TransManager").TryGetComponent(out _transManager);

            base.Start();
        }

        protected override async void OnClick()
        {
            await _transManager.TransitionScene(nextScene);
        }
    }
}