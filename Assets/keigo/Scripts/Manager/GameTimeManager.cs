using Cysharp.Threading.Tasks;
using UI.Result;
using UniRx;
using UnityEngine;

namespace Manager
{
    public class GameTimeManager : MonoBehaviour
    {
        [SerializeField] private float maxTimeSec = 180;

        private readonly ReactiveProperty<float> _elapsedSec = new();

        private GameStateManager _stateManager;

        public static GameTimeManager Instance
        {
            get
            {
                GameObject.FindWithTag("GameTimeManager").TryGetComponent(out GameTimeManager timeManager);
                return timeManager;
            }
        }

        public IReadOnlyReactiveProperty<float> ElapsedTimeSec => _elapsedSec;
        public float MaxTimeSec => maxTimeSec;

        private void Start()
        {
            _stateManager = GameStateManager.Instance;

            _stateManager.OnStateChange.Where(e => e == GameState.Playing).Subscribe(_ => { _elapsedSec.Value = 0; })
                .AddTo(this);
        }

        private void FixedUpdate()
        {
            if (_stateManager.GetCurrentState() != GameState.Playing) return;
            
            if (_elapsedSec.Value > maxTimeSec)
            {
                GameStateManager.Instance.PublishState(GameState.Pause);
                UniTask.Create(async () => await WindowManager.Instance.OpenWindow<ResultWindow>());
            }
            
            _elapsedSec.Value += Time.fixedDeltaTime;
        }
    }
}