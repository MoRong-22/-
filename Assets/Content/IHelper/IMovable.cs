using System.Numerics;

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
        /// 实例速度
        /// </summary>
        Vector3 Velocity { get; set; }
    }
}
