using keigo.Scripts.Common;
using UnityEngine;

namespace Manager
{
    /// <summary>
    /// ゲーム全体のステート管理
    /// </summary>
    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager Instance
        {
            get
            {
                GameObject.FindWithTag("GameStateManager").TryGetComponent(out GameStateManager manager);
                return manager;
            }
        }

        private GameState _currentState;

        public void PublishState(GameState newState)
        {
            
        }
    }

    public enum GameState
    {
        /// <summary>
        /// タイトル画面
        /// </summary>
        Title,
        /// <summary>
        /// プレイ中
        /// </summary>
        Playing,
        /// <summary>
        /// ポーズ中
        /// </summary>
        Pause
    }
}