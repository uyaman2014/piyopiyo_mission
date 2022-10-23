using UnityEngine;

namespace Manager
{
    public class ScoreManager: MonoBehaviour
    {
        public static ScoreManager Instance
        {
            get
            {
                GameObject.FindWithTag("ScoreManager").TryGetComponent(out ScoreManager manager);
                return manager;
            }
        }

        private int _currentScore;

        /// <summary>
        /// スコアを増やす
        /// </summary>
        /// <param name="amount">増やす量(マイナスだったら減ります)</param>
        public void IncreaseScore(int amount)
        {
            _currentScore += amount;
        }
    }
}