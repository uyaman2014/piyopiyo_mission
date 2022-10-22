﻿#if UNITY_EDITOR
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
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}