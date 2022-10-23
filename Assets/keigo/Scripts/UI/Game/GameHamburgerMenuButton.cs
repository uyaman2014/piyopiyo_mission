using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using keigo.Scripts.Common;
using Manager;
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

        private GameStateManager _stateManager;

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

        protected override void Start()
        {
            _stateManager = GameStateManager.Instance;

            base.Start();
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
            
            _stateManager.PublishState(GameState.Pause);
        }

        /// <summary>
        ///     再開
        /// </summary>
        public void Resume()
        {
            pauseUI.gameObject.SetActive(false);
            MoveRectX(pauseUI.rectTransform, -_pauseUIWidth, 0.1f)
                .OnComplete(() => MoveRectX(minimapContainer.rectTransform, _minimapInitX, 0.1f));
            
            _stateManager.PublishState(GameState.Playing);
        }

        protected override void OnClick()
        {
            var isPaused = pauseUI.rectTransform.position.x >= 0;

            if (isPaused)
                Resume();
            else
                Pause();
        }
    }
}