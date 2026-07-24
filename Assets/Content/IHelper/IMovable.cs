using UnityEngine;

namespace Content.IHelper
{
    /// <summary>
    /// 可运动接口
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// 实例中心/位置
        /// </summary>
        Vector3 Center { get; set; }
        /// <summary>
        /// 旋转值
        /// </summary>
        Quaternion Rotation { get; set; }
        /// <summary>
        /// 实例速度方向
        /// </summary>
        Vector3 Velocity { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        float Speed { get; set; }
    }
}
