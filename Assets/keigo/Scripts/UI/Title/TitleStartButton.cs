using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    /// <summary>
    ///     タイトルのスタートボタン
    /// </summary>
    public class TitleStartButton : UIButton
    {
        [SerializeField] private string nextSceneName = "SampleScene";
        private Button _button;
        private SceneTransManager _transManager;

        protected override void Start()
        {
            GameObject.FindWithTag("TransManager").TryGetComponent(out _transManager);

            base.Start();
        }

        protected override async void OnClick()
        {
            GameStateManager.Instance.PublishState(GameState.Playing);
            await _transManager.TransitionScene(nextSceneName);
        }
    }
}