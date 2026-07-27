using UnityEngine;
    /// <summary>
    /// 所有角色基类（玩家、怪物通用战斗属性）
    /// </summary>
    public abstract class CharacterBase : ICharacterStat
    {
        #region 基础面板属性（角色原生属性）
        public int baseMaxHealth;
        public int baseAttack;
        public int baseDefense;
        #endregion
        #region 接口属性实现
        public int CurrentHealth { get; set; }
        /// <summary>
        /// 最大生命值
        /// </summary>
        public virtual int MaxHealth
        {
            get
            {
                return baseMaxHealth;
            }
        }
        /// <summary>
        /// 攻击力
        /// </summary>
        public virtual int Attack
        {
            get
            {
                return baseAttack;
            }
        }
        /// <summary>
        /// 防御力
        /// </summary>
        public virtual int Defense
        {
            get
            {
                return baseDefense;
            }
        }
        #endregion
        public CharacterBase()
        {
        }
        /// <summary>
        /// 角色初始化/复活重置状态
        /// </summary>
        public virtual void InitCharacter()
        {
            CurrentHealth = MaxHealth;
        }
        /// <summary>
        /// 受到伤害【核心伤害公式】
        /// </summary>
        public virtual void TakeDamage(int rawDamage)
        {
            float damageScale = 100f / (100f + Defense);
            int finalDamage = Mathf.RoundToInt(rawDamage * damageScale);

            CurrentHealth -= finalDamage;
            if (CurrentHealth <= 0)
            {
                OnDeath();
            }
        }
        /// <summary>
        /// 治疗回血
        /// </summary>
        public virtual void Heal(int value)
        {
            CurrentHealth += value;
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
        }
        /// <summary>
        /// 死亡回调，子类重写
        /// </summary>
        protected abstract void OnDeath();
    }
