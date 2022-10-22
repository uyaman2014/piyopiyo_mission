using UnityEngine;

namespace UI.Game
{
    public class ReturnGameButton : UIButton
    {
        [SerializeField] private GameHamburgerMenuButton hamburgerMenuButton;

#if UNITY_EDITOR
        private void Reset()
        {
            hamburgerMenuButton = GetComponentInParent<GameHamburgerMenuButton>();
        }
#endif

        protected override void OnClick()
        {
            hamburgerMenuButton.Resume();
        }
    }
}