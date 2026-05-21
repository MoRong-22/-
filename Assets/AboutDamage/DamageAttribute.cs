using System.Drawing;

namespace AboutDamage
{
    //TODO： 专门服务于法术伤害 法术的细分支
    /// <summary>
    /// 伤害属性类
    /// </summary>
    public abstract class DamageAttribute
    {
        #region 基础字段
        /// <summary>
        /// 属性名字
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 属性伤害( 该伤害继承当前攻击伤害 特殊效果方法自己造（
        /// </summary>
        public float damageAttribute;
        /// <summary>
        /// 属性适配的颜色
        /// </summary>
        public Color color;
        #endregion
    }
}