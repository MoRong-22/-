using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全局玩家公共背包，所有友方角色共享
/// </summary>
public class GlobalPlayerInventory
{
    /// <summary>
    /// 全局唯一实例
    /// </summary>
    public static GlobalPlayerInventory Instance { get; private set; }
    /// <summary>
    /// 背包内装备列表
    /// </summary>
    public List<Equipment> Inventory { get; set; }

    static GlobalPlayerInventory()
    {
        Instance = new GlobalPlayerInventory();
    }

    public GlobalPlayerInventory()
    {
        Inventory = new List<Equipment>();
    }
    /// <summary>
    /// 清空背包，新游戏开始调用
    /// </summary>
    public void ClearInventory()
    {
        Inventory.Clear();
    }
}