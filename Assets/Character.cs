using UnityEngine;

public abstract class Character
{
    #region 角色的基础数值
    /// <summary>
    /// 最大血量
    /// </summary>
    public float MaxLife { get; private set; }
    /// <summary>
    /// 当前血量
    /// </summary>
    public float StatLife { get;set; }
    /// <summary>
    /// 最大魔力
    /// </summary>
    public float ManaMax { get; private set; }
    /// <summary>
    /// 当前魔力
    /// </summary>
    public float StatMana { get; set; }
    /// <summary>
    /// 技能组
    /// </summary>
    public Skill[] Skills { get; private set; }
    /// <summary>
    /// 物抗
    /// </summary>
    public float PhysicalDefense { get; private set; }
    /// <summary>
    /// 法抗
    /// </summary>
    public float MagicDefense { get; private set; }
    /// <summary>
    /// 伤害减免
    /// </summary>
    public float DamageReduce{ get; private set; }
    #endregion
}
