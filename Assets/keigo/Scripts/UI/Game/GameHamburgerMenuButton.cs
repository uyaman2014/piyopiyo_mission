using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using keigo.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game
{
    public class GameHamburgerMenuButton : UIButton
    {
        [SerializeField] private Image pauseUI;
        [SerializeField] private Image minimapContainer;
        private float _minimapWidth, _minimapInitX;
        private float _pauseUIWidth;

        // TODO: 注入
        private IPoseExecutor _poseExecutor;

        private void Awake()
        {
            _pauseUIWidth = pauseUI.rectTransform.sizeDelta.x;
            _minimapWidth = minimapContainer.rectTransform.sizeDelta.x;
            _minimapInitX = minimapContainer.rectTransform.anchoredPosition.x;
            ;

            var pos = pauseUI.rectTransform.localPosition;
            pos.x -= _pauseUIWidth;
            pauseUI.rectTransform.localPosition = pos;
        }

        private TweenerCore<float, float, FloatOptions> MoveRectX(RectTransform rect, float endValue, float duration)
        {
            return DOTween.To(() => rect.anchoredPosition.x, value =>
            {
                var pos = rect.anchoredPosition;
                pos.x = value;
                rect.anchoredPosition = pos;
            }, endValue, duration);
        }

        /// <summary>
        ///     ポーズする
        /// </summary>
        public void Pause()
        {
            pauseUI.gameObject.SetActive(true);
            MoveRectX(minimapContainer.rectTransform, -_minimapWidth, 0.1f)
                .OnComplete(() => MoveRectX(pauseUI.rectTransform, 0, 0.1f));

            _poseExecutor?.Pause();
        }

        /// <summary>
        ///     再開
        /// </summary>
        public void Resume()
        {
            pauseUI.gameObject.SetActive(false);
            MoveRectX(pauseUI.rectTransform, -_pauseUIWidth, 0.1f)
                .OnComplete(() => MoveRectX(minimapContainer.rectTransform, _minimapInitX, 0.1f));

            _poseExecutor?.Resume();
        }

        protected override void OnClick()
        {
            var isPaused = pauseUI.rectTransform.position.x >= 0;
            // TODO: ポーズ処理をどうするか相談
            // TODO: というか誰がポーズを管理するか

            if (isPaused)
                Resume();
            else
                Pause();
        }
    }
}