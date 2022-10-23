using UnityEngine;
using UnityEngine.Audio;

namespace Manager
{
    public class BGMManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private AudioMixerSnapshot[] snapShots;
        [SerializeField] private float[] initWeights;
        private float[] _weights;

        public static BGMManager Instance
        {
            get
            {
                GameObject.FindGameObjectWithTag("AudioManager").TryGetComponent(out BGMManager manager);
                return manager;
            }
        }

        private void Start()
        {
            _weights = initWeights;
        }

        /// <summary>
        ///     AudioMixerSnapShotをクロスフェードさせる
        /// </summary>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        public void CrossFadeSnapShot(int fromIndex, int toIndex)
        {
            _weights[fromIndex] = 0;
            _weights[toIndex] = 1;
            mixer.TransitionToSnapshots(snapShots, _weights, 1f);
        }
    }
}