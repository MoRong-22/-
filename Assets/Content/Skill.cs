using System;
using UnityEngine;

namespace  Content
{
    public abstract class Skill
    {
        public enum SkillType
        {
            Common, //普通技能
            Special, //特殊技能
            Passive, //被动技能
        }

        #region 技能构造

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="Name">技能名字</param>
        /// <param name="description">技能</param>
        /// <param name="damage">技能伤害</param>
        /// <param name="maxCharges">如果是次数技能的话 技能数量上限</param>
        /// <param name="countRangeTimeMax">技能数量恢复时间(秒)</param>
        /// <param name="manaCost">魔力消耗</param>
        /// <param name="cooldownMax">技能CD</param>
        /// <param name="currentCharges">技能数量</param> 
        public Skill(String Name, String description, float damage, int maxCharges, float countRangeTimeMax,
            float manaCost, float cooldownMax, int currentCharges = 1)
        {
            this.Name = Name;
            this.Description = description;
            this.damage = damage;
            this.maxCharges = maxCharges;
            this.countRangeTimeMax = countRangeTimeMax;
            this.manaCost = manaCost;
            this.cooldownMax = cooldownMax;
            this.currentCharges = currentCharges;
        }

        #endregion

        #region 技能的基本属性

        /// <summary>
        /// 技能显示贴图
        /// </summary>
        public Texture2D SkillTex { get; set; }

        /// <summary>
        /// 伤害
        /// </summary>
        public float damage;

        /// <summary>
        /// 技能最高数
        /// </summary>
        public int maxCharges;

        /// <summary>
        /// 当前技能数
        /// </summary>
        public int currentCharges;

        /// <summary>
        /// 技能恢复时间
        /// </summary>
        public float CountRangeTime = 0;

        /// <summary>
        /// 技能恢复最大时间
        /// </summary>
        public float countRangeTimeMax;

        /// <summary>
        /// 魔力消耗
        /// </summary>
        public float manaCost;

        /// <summary>
        /// 技能CD
        /// </summary>
        public float Cooldown = 0;

        /// <summary>
        /// 最大CD
        /// </summary>
        public float cooldownMax;

        /// <summary>
        /// 正在冷却
        /// </summary>
        public bool IsCD
        {
            get => Cooldown > 0;
        }

        /// <summary>
        /// 拥有技能
        /// </summary>
        public bool HasSkillCount
        {
            get => currentCharges == 0;
        }

        /// <summary>
        /// 魔力足够
        /// </summary>
        public bool ManaEnough
        {
            get => manaCost < character().CurrentMana;
        }

        #endregion

        #region 技能的基本信息

        /// <summary>
        /// 技能名字
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 技能信息
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 技能类型
        /// </summary>
        public SkillType skillType;

        #endregion

        #region 技能的持续时间

        /// <summary>
        /// 技能当前耗时
        /// </summary>
        public float SkillTime { get; private set; }

        /// <summary>
        /// 技能总耗时
        /// </summary>
        public float MaxTime { get; private set; }

        /// <summary>
        /// 技能是否结束
        /// </summary>
        public bool SkillEnd
        {
            get => SkillTime >= MaxTime;
        }

        #endregion

        #region 技能的方法

        /// <summary>
        /// 冷却更新
        /// </summary>
        public virtual void CD_Update()
        {
            if (IsCD)
            {
                Cooldown -= Time.deltaTime;
            }
        }

        /// <summary>
        /// 能否使用技能
        /// </summary>
        /// <returns></returns>
        public virtual bool CanUseSkill() => !IsCD && HasSkillCount && ManaEnough;

        /// <summary>
        /// 技能使用
        /// </summary>
        public virtual void Use()
        {
            if (CanUseSkill()) return;
            character().CurrentMana -= manaCost;
            Cooldown = cooldownMax;
            SkillTime = 0;
            currentCharges -= 1;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public virtual void Update()
        {
            if (IsCD) CD_Update();
            if (!SkillEnd) SkillTime += Time.deltaTime;
        }

        /// <summary>
        /// 技能数量恢复
        /// </summary>
        public virtual void CountRecovery()
        {
            if (currentCharges < maxCharges)
            {
                CountRangeTime += Time.deltaTime;
                if (CountRangeTime > countRangeTimeMax)
                {
                    currentCharges += 1;
                    CountRangeTime = 0;
                }
            }
        }

        #endregion

        #region 获取技能伴随实例

        /// <summary>
        /// 闭包技能对应的投射物
        /// </summary>
        private Func<Projectile> projectile;

        private Func<Character> character;

        /// <summary>
        /// 设置对应的投射物
        /// </summary>
        /// <param name="projectileFunc"></param>
        public void SetProjectile(Func<Projectile> projectileFunc) => projectile = projectileFunc;

        public void SetCharacter(Func<Character> characterFunc) => character = characterFunc;

        #endregion
    }
}
