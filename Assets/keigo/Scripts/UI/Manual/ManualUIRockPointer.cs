using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Manual
{
    public class ManualUIRockPointer : MonoBehaviour
    {
        private Image _image;

        private void Start()
        {
            TryGetComponent(out _image);
            
            DOTween.Sequence()
                .Join(_image.DOFade(1, 0.1f))
                .SetDelay(0.2f)
                .Append(_image.DOFade(0, 0.1f))
                .SetDelay(0.2f)
                .SetLoops(-1)
                .SetLink(gameObject)
                .Play();
        }
    }
}