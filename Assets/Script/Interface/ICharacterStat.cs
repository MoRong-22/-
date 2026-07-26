using UnityEngine;
    /// <summary>
    /// 角色属性统一接口
    /// </summary>
    public interface ICharacterStat
    {
        int MaxHealth { get; }
        int CurrentHealth { get; set; }
        int Attack { get; }
        int Defense { get; }

        /// <summary>
        /// 受到伤害
        /// </summary>
        void TakeDamage(int rawDamage);
        /// <summary>
        /// 治疗回血
        /// </summary>
        void Heal(int value);
    }
