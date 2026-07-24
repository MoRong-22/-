using AboutCollide;

namespace Content.IHelper
{
    /// <summary>
    /// 碰撞接口
    /// </summary>
    public interface IColliding
    {
        /// <summary>
        /// 碰撞箱
        /// </summary>
        HitBox HitBox { get; set; }
        /// <summary>
        /// 碰撞方法
        /// </summary>
        /// <param name="targetBox">目标碰撞箱</param>
        /// <returns></returns>
        bool Colliding(HitBox targetBox);
        /// <summary>
        /// 修改碰撞箱
        /// </summary>
        /// <param name="box">修改的碰撞箱参数</param>
        void ModifyHitBox(HitBox box);
    }
}