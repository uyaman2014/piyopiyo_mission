using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game
{
    public class GameTimeUI : MonoBehaviour, ITimeUI
    {
        [SerializeField] private TextMeshProUGUI minuteText, secondText;
        [SerializeField] private Image gaugeUI;

        private float _elapsedSec;
        private float _maxTimeSec;

        private void Start()
        {
            gaugeUI.fillAmount = 1;
        }


        public void SetMaxTimeSec(float second)
        {
            if (second < 0) throw new ArgumentException("設定する秒数は0以上にしてください");

            _maxTimeSec = second;
        }

        public void IncreaseElapsedSec(float amount)
        {
            if (amount < 0) throw new ArgumentException("設定する秒数は0以上にしてください");

            _elapsedSec += amount;

            var timeLeft = _maxTimeSec - _elapsedSec;
            // TODO: 残り時間が0秒より小さくなった場合はとりあえず無視
            if (timeLeft < 0) return;

            minuteText.text = ((int)(timeLeft / 60)).ToString();
            secondText.text = ((int)(timeLeft % 60)).ToString();
            gaugeUI.fillAmount = timeLeft / _maxTimeSec;
        }
    }

    public interface ITimeUI
    {
        /// <summary>
        ///     制限時間の最大値を設定
        /// </summary>
        /// <param name="second">制限時間の最大値</param>
        void SetMaxTimeSec(float second);

        /// <summary>
        ///     経過時間を増やす
        /// </summary>
        /// <param name="amount">増やす量</param>
        void IncreaseElapsedSec(float amount);
    }
}