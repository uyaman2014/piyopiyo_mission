using keigo.Scripts.Common;
using UnityEngine;
using UnityEngine.Audio;

namespace Manager
{
    public class BgmManager : SingletonMonoBehaviour<BgmManager>
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private AudioMixerSnapshot[] snapshots;
        private float[] _weights;

        private void Start()
        {
            _weights = new float[snapshots.Length];
        }

        public void Transition(int to, float fade = 2f)
        {
            for (var i = 0; i < _weights.Length; i++) _weights[i] = 0;
            _weights[to] = 1;
            mixer.TransitionToSnapshots(snapshots, _weights, fade);
        }
    }
}