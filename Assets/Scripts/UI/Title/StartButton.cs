using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Title
{
    /// <summary>
    ///     タイトルのスタートボタン
    /// </summary>
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private string nextSceneName = "SampleScene";
        private Button _button;
        private SceneTransManager _transManager;

        private void Start()
        {
            TryGetComponent(out _button);
            GameObject.FindWithTag("TransManager").TryGetComponent(out _transManager);

            _button.onClick.AddListener(async () => await _transManager.TransitionScene(nextSceneName));
        }
    }
}