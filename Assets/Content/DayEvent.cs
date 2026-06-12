using System;
using UnityEngine;
using Random = System.Random;

//TODO : 每日事件 包含事件的名字 描述 以及事件的触发条件 以及事件的结果
namespace Content
{
    public abstract class DayEvent : MonoBehaviour
    {
        #region 基础字段
        /// <summary>
        /// 事件名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 事件描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 事件稀有度
        /// </summary>
        public Rare Rarity { get; set; }
        /// <summary>
        /// 稀有度颜色
        /// </summary>
        public Color RarityColor { get; set; }
        /// <summary>
        /// 是否结束
        /// </summary>
        public bool End { get; set; }
        #endregion
        public enum Rare
        {
            Common,//普通
            Uncommon,//不常见
            Rare,//稀有
            Epic,//史诗
            Legendary//传奇
        }
        /// <summary>
        /// 随机数
        /// </summary>
        private Random _random = new Random();
        
        #region 基础方法
        /// <summary>
        /// 获取战利品
        /// </summary>
        public virtual void GetSpoils()
        {

        }
        /// <summary>
        /// 事件结束
        /// </summary>
        public virtual void EventEnd()
        {

        }
        /// <summary>
        /// 事件开始
        /// </summary>
        public virtual void EventStart()
        {
        }
        /// <summary>
        /// 事件更新
        /// </summary>
        public virtual void EventUpdate()
        {
        
        }
        /// <summary>
        /// 修改每日事件的方法
        /// </summary>
        /// <param name="event"></param>
        /// <typeparam name="T"></typeparam>
        public static void SetEvent<T>(T @event) where T : DayEvent
        {
            Game.Instance.DayEvents = @event;
        }
        #endregion
    }
}

