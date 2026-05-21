using System;

namespace AboutDamage
{
    /// <summary>
    /// 伤害的类
    /// </summary>
    public class Damage_class
    {
        #region 伤害类的基础数值
        /// <summary>
        /// 伤害类型
        /// </summary>
        public Damage_enum damage_enum;
        /// <summary>
        /// 伤害值
        /// </summary>
        public float damage;
        /// <summary>
        /// 你是怎么看见他的？
        /// </summary>
        private float physicalPentrate_Percentage;
        /// <summary>
        /// 物穿_百分比 
        /// </summary>
        public float PhysicalPentrate_Percentage
        {
            get => physicalPentrate_Percentage;
            set => physicalPentrate_Percentage = Math.Clamp(value, 0f, 1f);
        }
        /// <summary>
        /// 你是怎么看见他的？
        /// </summary>
        private float magicPentrate_Percentage;
        /// <summary>
        /// 法穿_百分比
        /// </summary>
        public float MagicPentrate_Percentage
        {
            get => magicPentrate_Percentage;
            set => magicPentrate_Percentage = Math.Clamp(value, 0f, 1f);
        }
        /// <summary>
        /// 物穿
        /// </summary>
        public float PhysicsPenetrate;
        /// <summary>
        /// 法穿
        /// </summary>
        public float MagicPenetrate;
        /// <summary>
        /// 爆率
        /// </summary>
        public float CriticalRate;
        /// <summary>
        /// 倍率
        /// </summary>
        public float CriticalMultiplier;
        /// <summary>
        /// 伤害波动_最小值
        /// </summary>
        public float DamageFluctuation_min = 0.95f;
        /// <summary>
        /// 伤害波动_最大值
        /// </summary>
        public float DamageFluctuation_max = 1.05f;
        #endregion
        /// <summary>
        /// 随机数
        /// </summary>
        private Random random = new Random();

        #region 伤害计算方法
        /// <summary>
        /// 是否暴击
        /// </summary>
        /// <returns></returns>
        public bool Crit() => CriticalRate > random.Next(100);
        /// <summary>
        /// 获取伤害
        /// </summary>
        /// <param name="target">被击打的目标</param>
        /// <returns></returns>
        public float GetDamage(NPC target)
        {
            if(damage_enum == Damage_enum.Really)
                return damage;
            else if(damage_enum == Damage_enum.Magic)
                return GetFluctuation() * damage *
                       (100 / (100 + (target.MagicDefense - MagicPenetrate) * (1 - MagicPentrate_Percentage)));
            else
                return GetFluctuation() * damage *
                       (100 / (100 + (target.PhysicalDefense - PhysicsPenetrate) * (1 - PhysicalPentrate_Percentage)));
        }
        /// <summary>
        /// 计算暴击后伤害返回
        /// </summary>
        /// <param name="target">被击打的目标</param>
        /// <returns></returns>
        public float CauseDamage(NPC target)
        {
            float final_damage = GetDamage(target);
            if (Crit())
                final_damage *= CriticalMultiplier;
            return final_damage;
        }
        /// <summary>
        /// 获取伤害
        /// </summary>
        /// <param name="target">玩家</param>
        /// <returns></returns>
        public float GetDamage(Character target)
        {
            if(damage_enum == Damage_enum.Really)
                return damage;
            else if(damage_enum == Damage_enum.Magic)
                return GetFluctuation() * damage * 
                       (100 / (100 + (target.MagicDefense - MagicPenetrate) * (1 - MagicPentrate_Percentage)));
            else
                return GetFluctuation() * damage *
                    (100 / (100 + (target.PhysicalDefense - PhysicsPenetrate) * (1 - PhysicalPentrate_Percentage)));
        }
        /// <summary>
        /// 计算暴击后伤害返回
        /// </summary>
        /// <param name="target">玩家</param>
        /// <returns></returns>
        public float CauseDamage(Character target)
        {
            float final_damage = GetDamage(target);
            if (Crit())
                final_damage *= CriticalMultiplier;
            return final_damage;
        }
        /// <summary>
        /// 获取浮动值
        /// </summary>
        /// <returns></returns>
        private float GetFluctuation()
        {
            float min = DamageFluctuation_min * 100f;
            float max = DamageFluctuation_max * 100f;
            return random.Next((int)min, (int)max) / 100f;
        }
        #endregion
    }
}