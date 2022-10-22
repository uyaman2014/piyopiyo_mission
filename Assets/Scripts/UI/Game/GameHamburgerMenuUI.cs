using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game
{
    public class GameHamburgerMenuUI : UIButton
    {
        [SerializeField] private Image pauseUI;
        private float _width;

        private void Awake()
        {
            _width = pauseUI.rectTransform.sizeDelta.x;

            var pos = pauseUI.rectTransform.localPosition;
            pos.x -= _width;
            pauseUI.rectTransform.localPosition = pos;
        }

        protected override void OnClick()
        {
            var moveValue = pauseUI.rectTransform.position.x >= 0 ? -_width : 0;

            DOTween.To(() => pauseUI.rectTransform.anchoredPosition.x, value =>
            {
                var pos = pauseUI.rectTransform.anchoredPosition;
                pos.x = value;
                pauseUI.rectTransform.anchoredPosition = pos;
            }, moveValue, 0.1f);
        }
    }
}