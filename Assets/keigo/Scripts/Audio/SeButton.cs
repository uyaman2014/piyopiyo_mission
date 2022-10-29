using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace keigo.Scripts.Audio
{
    [RequireComponent(typeof(Button))]
    public class SeButton : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;
        private Button _button;

        private void Start()
        {
            TryGetComponent(out _button);
            _button.onClick.AddListener(() => SeManager.Instance.PlayOneShot(audioClip, 1));
        }
    }
}