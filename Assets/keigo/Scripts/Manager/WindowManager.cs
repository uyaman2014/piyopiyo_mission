using UI.Window;
using UnityEngine;

namespace Manager
{
    /// <summary>
    /// 同じシーン内でウィンドウを開く
    /// </summary>
    public class WindowManager : MonoBehaviour
    {
        /// <summary>
        /// 指定されたウィンドウをリソースから読み込んで表示
        /// </summary>
        /// <param name="resourceName"></param>
        public void OpenWindow(string resourceName)
        {
            var window = Resources.LoadAsync<BaseWindow>(resourceName);
            
        }
    }
}