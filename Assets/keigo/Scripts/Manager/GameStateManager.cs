using System;
using UniRx;
using UnityEngine;

namespace Manager
{
    /// <summary>
    ///     ゲーム全体のステート管理
    /// </summary>
    public class GameStateManager : MonoBehaviour
    {
        private ReactiveProperty<GameState> _currentState;

        public static GameStateManager Instance
        {
            get
            {
                GameObject.FindWithTag("GameStateManager").TryGetComponent(out GameStateManager manager);
                return manager;
            }
        }

        public IObservable<GameState> OnStateChange => _currentState;

        private void Start()
        {
            OnStateChange.Where(e => e == GameState.Pause).Subscribe(_ => Time.timeScale = 0).AddTo(this);
            OnStateChange.Where(e => e != GameState.Pause).Subscribe(_ => Time.timeScale = 1).AddTo(this);
        }

        /// <summary>
        ///     ステートを変更
        /// </summary>
        /// <param name="newState">新しいステート</param>
        public void PublishState(GameState newState)
        {
            _currentState.Value = newState;
        }

        /// <summary>
        ///     現在のステートを取得
        /// </summary>
        /// <returns></returns>
        public GameState GetCurrentState()
        {
            return _currentState.Value;
        }
    }

    public enum GameState
    {
        /// <summary>
        ///     タイトル画面
        /// </summary>
        Title,

        /// <summary>
        ///     プレイ中
        /// </summary>
        Playing,

        /// <summary>
        ///     ポーズ中
        /// </summary>
        Pause
    }
}