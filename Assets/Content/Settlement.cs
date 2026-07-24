using System;
using System.Collections.Generic;
using System.Linq;

namespace Content
{
    // 放 Game 里或单独文件
    public class Settlement
    {
        /// <summary>
        /// 击杀存档
        /// </summary>
        public Dictionary<string, int> KillCounts = new();
        public int TotalKills => KillCounts.Values.Sum();
        /// <summary>
        /// 击杀敌怪记录
        /// </summary>
        /// <param name="kill">敌怪</param>
        /// <param name="amount">次数</param>
        public void KillRecord(string kill,int amount)
        {
            if (!KillCounts.ContainsKey(kill))
            {
                KillCounts.Add(kill, amount);
            }
            else
            {
                KillCounts[kill] += amount;
            }
        }
        /// <summary>
        /// 技能存档
        /// </summary>
        public Dictionary<string, int> SkillUses = new();
        public List<string> SkillLog = new();
        /// <summary>
        /// 技能使用记录
        /// </summary>
        /// <param name="skill">技能</param>
        /// <param name="amount">次数</param>
        public void SkillRecord(string skill, int amount)
        {
            if (!SkillUses.ContainsKey(skill))
            {
                SkillUses.Add(skill, amount);
            }
            else
            {
                SkillUses[skill] += amount;
            }
        }
        /// <summary>
        /// 受伤/治疗存档
        /// </summary>
        public float TotalDamageTaken;
        public float TotalHealthRestored;
        /// <summary>
        /// 奖励记录
        /// </summary>
        public List<string> RewardsObtained = new();

        /// <summary>
        /// 道具使用
        /// </summary>
        public Dictionary<string, int> ItemUses = new();
        /// <summary>
        /// 道具记录
        /// </summary>
        /// <param name="item">道具</param>
        /// <param name="amount">数量</param>
        public void ItemRecord(string item, int amount)
        {
            if (!ItemUses.ContainsKey(item))
            {
                ItemUses.Add(item, amount);
            }
            else
            {
                ItemUses[item] += amount;
            }
        }
        /// <summary>
        /// 事件记录
        /// </summary>
        public List<string> EventsTriggered = new();
    }
}