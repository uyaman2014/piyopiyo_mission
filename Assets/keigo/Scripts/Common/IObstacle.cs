using UnityEngine;

namespace keigo.Scripts.Common
{
    /// <summary>
    /// 障害物のインターフェース
    /// </summary>
    public interface IMovingObstacle
    {
        
    }

    /// <summary>
    /// スピードアップ等の副作用がある障害物
    /// </summary>
    public interface IEffectObstacle
    {
        /// <summary>
        /// これに当たった時のスピードの変化量
        /// </summary>
        float SpeedChangeAmount { get; }
    }
}