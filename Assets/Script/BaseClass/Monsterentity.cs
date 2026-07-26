using System;
using UnityEngine;

    /// <summary>
    /// 怪物实体，无装备系统
    /// </summary>
    public class MonsterEntity : CharacterBase
    {
    /// <summary>
    /// 怪物死亡委托，死亡时触发
    /// </summary>
    public Action MonsterDeadEvent;

    protected override void OnDeath()
        {
            Debug.Log("怪物被击杀");
            //怪物销毁、掉落物品逻辑
            MonsterDeadEvent?.Invoke();
        }
    }
