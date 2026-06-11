using System;
using Content;
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
        /// 更新(每帧
        /// </summary>
        /// <param name="c">角色</param>
        public void Update(Character c)
        {
            timer += Time.deltaTime;
            timeLeft-= Time.deltaTime;
            Update_Frame(c);
            if (timer >= 1f)
            {
                timer -= 1f;
                Update_Second(c);
            }
        }
        /// <summary>
        /// 更新(每秒
        /// </summary>
        /// <param name="c">角色</param>
        public virtual void Update_Second(Character c){}
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="c">角色</param>
        public virtual void Update_Frame(Character c){}
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