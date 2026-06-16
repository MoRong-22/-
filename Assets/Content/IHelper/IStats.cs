namespace Content.IHelper
{
    /// <summary>
    /// 状态接口
    /// </summary>
    public interface IStats
    {
        /// <summary>
        /// 最大生命值
        /// </summary>
        float MaxHealth { get; set; }
        /// <summary>
        /// 当前生命值
        /// </summary>
        float CurrentHealth { get; set; }
        /// <summary>
        /// 生命恢复
        /// </summary>
        float HealthRegen { get; set; }
        /// <summary>
        /// 最大魔力
        /// </summary>
        float MaxMana { get; set; }
        /// <summary>
        /// 当前魔力
        /// </summary>
        float CurrentMana { get; set; }
        /// <summary>
        /// 魔力恢复
        /// </summary>
        float ManaRegen { get; set; }
        /// <summary>
        /// 物理抗性
        /// </summary>
        float PhysicalDefense { get; set; }
        /// <summary>
        /// 魔法抗性
        /// </summary>
        float MagicDefense { get; set; }
        /// <summary>
        /// 伤害减免
        /// </summary>
        float DamageReduce { get; set; }
        /// <summary>
        /// 是否存活
        /// </summary>
        bool IsActive { get; }
    }
}
