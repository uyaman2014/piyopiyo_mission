using Manager;
using UnityEngine;

namespace UI.Title
{
    /// <summary>
    ///     タイトルシーンの初期化処理
    /// </summary>
    public class TitleInitializer : MonoBehaviour
    {
        private void Start()
        {
            GameStateManager.Instance.PublishState(GameState.Title);
            BgmManager.Instance.Transition(0);
        }
    }
}