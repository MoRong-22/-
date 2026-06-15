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
        /// 技能存档
        /// </summary>
        public Dictionary<string, int> SkillUses = new();
        public List<string> SkillLog = new();

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
        /// 事件记录
        /// </summary>
        public List<string> EventsTriggered = new();
    }
}