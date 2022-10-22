using UnityEngine;

namespace keigo.Scripts.Common
{
    /// <summary>
    ///     動く障害物のインターフェース
    /// </summary>
    public interface IMovingObstacle
    {
        /// <summary>
        ///     これに当たった時の雛の散らばり具合
        /// </summary>
        float Scattered { get; }
    }

    /// <summary>
    ///     スピードアップ等の副作用がある障害物
    /// </summary>
    public interface IEffectObstacle
    {
        /// <summary>
        ///     これに当たった時のスピードの変化量
        /// </summary>
        float SpeedChangeAmount { get; }

        /// <summary>
        ///     この障害物に触れたときに与えられるベクトル
        /// </summary>
        Vector2 AwayVector { get; }
    }

    /// <summary>
    ///     動く障害物の抽象クラス
    ///
    ///     IMovingObstacleを実装するときのサンプルにしてくれれば...
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public abstract class MovingObstacle : MonoBehaviour, IMovingObstacle
    {
        [SerializeField] protected Vector2 moveVector;
        [SerializeField] protected float speedSmooth = 10f;
        [SerializeField] private bool flip;
        [SerializeField] private float scattered = 5f;
        private SpriteRenderer _renderer;

        private Rigidbody2D _rigid;

        protected virtual void Start()
        {
            TryGetComponent(out _rigid);
            TryGetComponent(out _renderer);
        }

        protected virtual void FixedUpdate()
        {
            _rigid.velocity = Vector2.Lerp(_rigid.velocity, moveVector, speedSmooth);
            if (flip)
                _renderer.flipX = moveVector.x < 0;
            else
                _renderer.flipX = moveVector.x > 0;
        }

        public float Scattered => scattered;
    }
}