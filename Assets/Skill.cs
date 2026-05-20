using System;
using UnityEngine;

public abstract class Skill
{
    public enum SkillType
    {
        Common,//普通技能
        Special,//特殊技能
        Passive,//被动技能
    }
    #region 技能构造
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="Damage">技能伤害</param>
    /// <param name="MaxCharges">如果是次数技能的话 技能数量上限</param>
    /// <param name="CountRangeTimeMax">技能数量恢复时间(秒)</param>
    /// <param name="ManaCost">魔力消耗</param>
    /// <param name="CooldownMax">技能CD</param>
    public Skill(float Damage,int MaxCharges,float CountRangeTimeMax,float ManaCost,float CooldownMax,int CurrentCharges = 1)
    {
        this.Damage = Damage;
        this.MaxCharges = MaxCharges;
        this.CountRangeTimeMax = CountRangeTimeMax;
        this.ManaCost = ManaCost;
        this.CooldownMax = CooldownMax;
        this.CurrentCharges = CurrentCharges;
    }
    #endregion
    #region 技能的基本属性
    /// <summary>
    /// 技能显示贴图
    /// </summary>
    public Texture2D SkillTex {  get; set; }
    /// <summary>
    /// 伤害
    /// </summary>
    public float Damage;
    /// <summary>
    /// 技能最高数
    /// </summary>
    public int MaxCharges;
    /// <summary>
    /// 当前技能数
    /// </summary>
    public int CurrentCharges;
    /// <summary>
    /// 技能恢复时间
    /// </summary>
    public float CountRangeTime = 0;
    /// <summary>
    /// 技能恢复最大时间
    /// </summary>
    public float CountRangeTimeMax;
    /// <summary>
    /// 魔力消耗
    /// </summary>
    public float ManaCost;
    /// <summary>
    /// 技能CD
    /// </summary>
    public float Cooldown = 0;
    /// <summary>
    /// 最大CD
    /// </summary>
    public float CooldownMax;
    /// <summary>
    /// 正在冷却
    /// </summary>
    public bool IsCD { get => Cooldown > 0; }
    /// <summary>
    /// 拥有技能
    /// </summary>
    public bool HasSkillCount { get => CurrentCharges == 0; }
    /// <summary>
    /// 魔力足够
    /// </summary>
    public bool ManaEnough { get => ManaCost < character().StatMana; }
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
    public float SkillTime {  get; private set; }
    /// <summary>
    /// 技能总耗时
    /// </summary>
    public float MaxTime { get; private set; }
    /// <summary>
    /// 技能是否结束
    /// </summary>
    public bool SkillEnd { get => SkillTime >= MaxTime;}
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
        character().StatMana -= ManaCost;
        Cooldown = CooldownMax;
        SkillTime = 0;
        CurrentCharges -= 1;
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
        if(CurrentCharges < MaxCharges)
        {
            CountRangeTime+= Time.deltaTime; 
            if(CountRangeTime > CountRangeTimeMax)
            {
                CurrentCharges += 1;
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
