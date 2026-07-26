using UnityEngine;
/// <summary>
/// 装备槽，存放当前穿戴装备
/// </summary>
public class Slot
{
    /// <summary>
    /// 当前穿戴装备
    /// </summary>
    public Equipment EquippedItem { get; private set; }
    /// <summary>
    /// 装备物品
    /// </summary>
    public bool Equip(Equipment item)
    {
        EquippedItem = item;
        return true;
    }
    /// <summary>
    /// 卸下装备，返回装备实例
    /// </summary>
    public Equipment UnEquip()
    {
        var temp = EquippedItem;
        EquippedItem = null;
        return temp;
    }
    /// <summary>
    /// 获取槽内装备提供的总属性加成
    /// </summary>
    public void GetBonus(out int hp, out int atk, out int def)
    {
        hp = 0;
        atk = 0;
        def = 0;
        if (EquippedItem == null) return;
        hp = EquippedItem.healthBonus;
        atk = EquippedItem.attackBonus;
        def = EquippedItem.defenseBonus;
    }
}