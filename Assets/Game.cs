using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    #region 每个游戏自带的实例

    /// <summary>
    /// 游戏实例
    /// </summary>
    public static Game instance;
    /// <summary>
    /// 每日结束
    /// </summary>
    public bool IsDayOver { get; private set; }
    /// <summary>
    /// 角色对象池 
    /// </summary>
    public List<Character>  Characters { get; private set; }
    /// <summary>
    /// 每日事件
    /// </summary>
    public DayEvent DayEvents { get; set; }
    /// <summary>
    /// 射弹对象池 
    /// </summary>
    public List<Projectile>  Projectiles { get; private set; }
    /// <summary>
    /// NPC对象池
    /// </summary>
    public List<NPC>   NPCs { get; private set; }

    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
