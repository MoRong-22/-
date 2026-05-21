using System.Drawing;
using AboutDamage;
using UnityEngine;

public class Projectile
{
    #region 射弹基础数值
    /// <summary>
    /// 碰撞箱
    /// </summary>
    public Collider Collider;
    /// <summary>
    /// 位置
    /// </summary>
    public Vector3 Position;
    /// <summary>
    /// 速度
    /// </summary>
    public Vector3 Velocity;
    /// <summary>
    /// 碰撞箱中心
    /// </summary>
    public Vector3 Center;
    /// <summary>
    /// 总旋转角
    /// </summary>
    public Quaternion Rotation;
    /// <summary>
    /// 是否存活
    /// </summary>
    public bool IsActive{get => timeLeft > 0f;}
    /// <summary>
    /// 射弹剩余时间
    /// </summary>
    public int timeLeft;
    /// <summary>
    /// 伤害值
    /// </summary>
    public Damage_class Damage;
    #endregion
}
