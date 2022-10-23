using System;
using Manager;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game
{
    public class GameTimeUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI minuteText, secondText;
        [SerializeField] private Image gaugeUI;

        private GameTimeManager _timeManager;

        private void Start()
        {
            gaugeUI.fillAmount = 1;

            _timeManager = GameTimeManager.Instance;

            _timeManager.ElapsedTimeSec.Subscribe(elapsed =>
            {
                var max = _timeManager.MaxTimeSec;
                var left = max - elapsed;

                minuteText.text = ((int)(left / 60)).ToString();
                secondText.text = ((int)(left % 60)).ToString();
                gaugeUI.fillAmount = left / max;
            }).AddTo(this);
        }
    }
}