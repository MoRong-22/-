using UnityEngine;
//TODO : 每日事件 包含事件的名字 描述 以及事件的触发条件 以及事件的结果
public abstract class DayEvent
{
    public string Name { get; set; }
    public string Description { get; set; }
    public enum Rare
    {
        Common,//普通
        Uncommon,//不常见
        Rare,//稀有
        Epic,//史诗
        Legendary//传奇
    }
    public Rare Rarity { get; set; }
    public bool End { get; set; }
    public void GetSpoils()
    {

    }
    public void EventEnd()
    {

    }
}
