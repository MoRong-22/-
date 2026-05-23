using System;
using Content;
using Unity.VisualScripting;
using UnityEngine;
namespace AboutDamage
{
    public abstract class StatusEffect
    {
        #region 基础字段
        /// <summary>
        /// 状态名字
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 状态总时间
        /// </summary>
        public float timeLeftMax;
        /// <summary>
        /// 剩余时间
        /// </summary>
        public float timeLeft;
        /// <summary>
        /// 层数
        /// </summary>
        public int stack;
        /// <summary>
        /// 总层数
        /// </summary>
        public int maxStack;
        /// <summary>
        /// 是否结束
        /// </summary>
        public bool IsOver{get => timeLeft <= 0;}
        /// <summary>
        /// 层数是否已满
        /// </summary>
        public bool StackIsMax{get => stack >= maxStack;}
        /// <summary>
        /// NPC
        /// </summary>
        private Func<NPC> _npc;
        /// <summary>
        /// 角色
        /// </summary>
        private Func<Character> _character;
        #endregion
        
        private float timer=0;

        #region 基本方法
        /// <summary>
        /// 绑定NPC
        /// </summary>
        /// <param name="npc">NPC</param>
        public void GetNPC(Func<NPC> npc) => _npc = npc;
        /// <summary>
        /// 绑定角色
        /// </summary>
        /// <param name="character">角色</param>
        public void GetCharacter(Func<Character> character) => _character = character;
        /// <summary>
        /// 更新(每帧
        /// </summary>
        public virtual void Update()
        {
            timer += Time.deltaTime;
            timeLeft-= Time.deltaTime;
            if (timer >= 1f)
            {
                timer -= 1f;
                Update_Second();
            }
        }
        /// <summary>
        /// 更新(每秒
        /// </summary>
        public virtual void Update_Second(){}
        /// <summary>
        /// 层数叠加
        /// </summary>
        public virtual void AddStack()
        {
            if(!StackIsMax)stack++;
        }
        #endregion
    }
}