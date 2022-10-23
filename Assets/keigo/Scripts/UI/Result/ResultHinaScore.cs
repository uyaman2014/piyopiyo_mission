using Manager;
using TMPro;
using UnityEngine;

namespace UI.Result
{
    public class ResultHinaScore : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Start()
        {
            TryGetComponent(out _text);

            _text.text = ScoreManager.Instance.GetCurrentScore().ToString();
        }
    }
}