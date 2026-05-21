using System.Collections.Generic;
using AboutDamage;
using UnityEngine;
public abstract class NPC
{
    #region NPC基础数值
    /// <summary>
    /// 是否友善
    /// </summary>
    public bool IsFriend { get; private set; }
    /// <summary>
    /// 是否存活
    /// </summary>
    public bool IsActived
    {
        get => StatLife <= 0;
    }
    /// <summary>
    /// NPC 名字
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// NPC 伤害
    /// </summary>
    public Damage_class Damage { get; private set; }
    /// <summary>
    /// 最大生命值
    /// </summary>
    public float MaxLife {  get; private set; }
    /// <summary>
    /// 当前生命值
    /// </summary>
    public float StatLife { get; private set; }
    /// <summary>
    /// 状态列表
    /// </summary>
    public List<StatusEffect> status;
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
