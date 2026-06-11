using System.Collections.Generic;
using AboutDamage;

namespace Content.IHelper
{
    /// <summary>
    /// 状态附着控制接口
    /// </summary>
    public interface IStatusEffectCaster
    {
        /// <summary>
        /// 状态列表
        /// </summary>
        List<StatusEffect> Effects { get; set; }
        /// <summary>
        /// 状态能否更新？
        /// </summary>
        /// <param name="effect">状态</param>
        /// <returns></returns>
        bool CanUpdateEffect(StatusEffect effect);
    }
}