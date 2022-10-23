using UniRx;
using UnityEngine;

namespace Manager
{
    public class ScoreManager : MonoBehaviour
    {
        private int _currentScore;
        private GameStateManager _stateManager;

        public static ScoreManager Instance
        {
            get
            {
                GameObject.FindWithTag("ScoreManager").TryGetComponent(out ScoreManager manager);
                return manager;
            }
        }

        private void Start()
        {
            _stateManager = GameStateManager.Instance;

            _stateManager.OnStateChange.Where(e => e == GameState.Playing).Subscribe(_ => ResetScore()).AddTo(this);
        }

        /// <summary>
        ///     スコアを増やす
        /// </summary>
        /// <param name="amount">増やす量(マイナスだったら減ります)</param>
        public void IncreaseScore(int amount)
        {
            _currentScore += amount;
        }

        /// <summary>
        ///     現在のスコアを取得
        /// </summary>
        /// <returns></returns>
        public int GetCurrentScore()
        {
            return _currentScore;
        }

        /// <summary>
        ///     スコアをリセット
        /// </summary>
        public void ResetScore()
        {
            _currentScore = 0;
        }
    }
}