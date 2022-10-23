using UnityEngine;

namespace Manager
{
    public class ScoreManager : MonoBehaviour
    {
        private int _currentScore;

        public static ScoreManager Instance
        {
            get
            {
                GameObject.FindWithTag("ScoreManager").TryGetComponent(out ScoreManager manager);
                return manager;
            }
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
        /// スコアをリセット
        /// </summary>
        public void ResetScore()
        {
            _currentScore = 0;
        }
    }
}