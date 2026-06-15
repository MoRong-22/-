using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// 随机数
        /// </summary>
        private Random _random = new Random();
        
        private static Dictionary<Rare, float> RareWeights = new()
        {
            { Rare.Common, 50 },      // 50% 概率
            { Rare.Uncommon, 25 },     // 25%
            { Rare.Rare, 15 },         // 15%
            { Rare.Epic, 8 },          // 8%
            { Rare.Legendary, 2 },     // 2%
        };
        public static List<DayEvent>  DayEvents { get;  set; }
        #region 基础方法
        public static DayEvent PickWeighted()
        {
            // 先随机稀有度，再在该稀有度里随机选一个
            float totalWeight = 0;
            foreach (var w in RareWeights.Values) totalWeight += w;

            float roll = UnityEngine.Random.Range(0, totalWeight);
            float acc = 0;
            Rare picked = Rare.Common;

            foreach (var kv in RareWeights)
            {
                acc += kv.Value;
                if (roll <= acc) { picked = kv.Key; break; }
            }

            // 从该稀有度的事件里随机取一个
            var candidates = DayEvents.Where(e => e.Rarity == picked).ToList();
            if (candidates.Count == 0)
                candidates = DayEvents;  // 该稀有度没事件时退回到所有事件

            return candidates[UnityEngine.Random.Range(0, candidates.Count)];
        }
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

