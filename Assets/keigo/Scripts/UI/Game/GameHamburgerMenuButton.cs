using DG.Tweening;
using keigo.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game
{
    public class GameHamburgerMenuButton : UIButton
    {
        [SerializeField] private Image pauseUI;
        // TODO: 注入
        private IPoseExecutor _poseExecutor;
        private float _width;

        private void Awake()
        {
            _width = pauseUI.rectTransform.sizeDelta.x;

            var pos = pauseUI.rectTransform.localPosition;
            pos.x -= _width;
            pauseUI.rectTransform.localPosition = pos;
        }

        /// <summary>
        /// ポーズする
        /// </summary>
        public void Pause()
        {
            pauseUI.gameObject.SetActive(true);
            DOTween.To(() => pauseUI.rectTransform.anchoredPosition.x, value =>
            {
                var pos = pauseUI.rectTransform.anchoredPosition;
                pos.x = value;
                pauseUI.rectTransform.anchoredPosition = pos;
            }, 0, 0.1f);
            
            _poseExecutor?.Pause();
        }

        /// <summary>
        /// 再開
        /// </summary>
        public void Resume()
        {
            pauseUI.gameObject.SetActive(false);
            DOTween.To(() => pauseUI.rectTransform.anchoredPosition.x, value =>
            {
                var pos = pauseUI.rectTransform.anchoredPosition;
                pos.x = value;
                pauseUI.rectTransform.anchoredPosition = pos;
            }, -_width, 0.1f);
            
            _poseExecutor?.Resume();
        }

        protected override void OnClick()
        {
            var isPaused = pauseUI.rectTransform.position.x >= 0;
            // TODO: ポーズ処理をどうするか相談
            // TODO: というか誰がポーズを管理するか

            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}