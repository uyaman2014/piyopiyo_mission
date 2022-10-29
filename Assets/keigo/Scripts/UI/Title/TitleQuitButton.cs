
using Manager;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UI.Title
{
    /// <summary>
    ///     タイトルの終了ボタン
    /// </summary>
    public class TitleQuitButton : UIButton
    {
        protected override void OnClick()
        {
            SeManager.Instance.PlayOneShot("Audio/SE/Button1", 1);
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#elif PLATFORM_WEBGL

#else
            Application.Quit();
#endif
        }
    }
}