using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace  Content
{
    //TODO : 游戏开始: NewDay执行 随机提供几个事件供玩家选择 然后等事件全部结束以后 结算 获取金币 道具 饰品 ！！每个角色都会有自己的专属饰品或者道具！！
    public class Game : MonoBehaviour
    {
        public GameObject GameOver;
        
        #region 每个游戏自带的实例
        /// <summary>
        /// 游戏实例
        /// </summary>
        public static Game Instance;
        /// <summary>
        /// 每日结束
        /// </summary>
        public bool IsDayOver { get; set; }
        /// <summary>
        /// 每日开始
        /// </summary>
        public bool IsDayOpen{get; set;}
        /// <summary>
        /// 开始游戏?
        /// </summary>
        public bool startGame = false;
        /// <summary>
        /// 角色对象池 
        /// </summary>
        public List<Character> Characters { get;set; } = new List<Character>();
        /// <summary>
        /// 游戏记录
        /// </summary>
        public Settlement Settlement { get; set; }
        /// <summary>
        /// 每日事件
        /// </summary>
        public DayEvent DayEvents { get; set; }
        /// <summary>
        /// 粒子对象池
        /// </summary>
        public List<Dusts> Dusts { get; set; } = new List<Dusts>();
        /// <summary>
        /// 射弹对象池 
        /// </summary>
        public List<Projectile> Projectiles { get; private set; } = new List<Projectile>();

        /// <summary>
        /// NPC对象池
        /// </summary>
        public List<NPC> NPCs { get; private set; } = new List<NPC>();
        /// <summary>
        /// 地图
        /// </summary>
        public Map Map { get; set; }
        
        public Character MainCharacter
        {
            get => Map.MainCharacter;
        }
        #endregion

        void Start()
        {
            
        }

        public void FixedUpdate()
        {
            foreach (Character character in Instance.Characters)
            {
                character.OnFixedUpdate();
            }

            foreach (NPC npc in Instance.NPCs)
            {
                npc.OnFixedUpdate();
            }

            foreach (Projectile proj in Instance.Projectiles)
            {
                proj.OnFixedUpdate();
            }

            foreach (Dusts dust in Instance.Dusts)
            {
                dust.OnFixedUpdate();
            }
        }
        
        public void Update()
        {
            MainCharacter.OnUpdate();
            //MainCharacter.OnDraw();
            foreach(Character character in Instance.Map.SecondaryCharacter)
            {
                character.OnUpdate();
                //character.OnDraw();
            }

            //foreach (NPC npc in Instance.NPCs)
            //{
            //    npc.OnUpdate();
            //    npc.OnDraw();
            //    if (npc.Colliding(MainCharacter.HitBox))
            //    {
            //        npc.OnHitCharacter(MainCharacter);
            //        MainCharacter.OnUnderAttack(npc);
            //    }
            //}

            //foreach (Projectile proj in Instance.Projectiles)
            //{
            //    proj.OnUpdate();
            //    proj.OnDraw();

            //    foreach (NPC npc in Instance.NPCs)
            //    {
            //        if (proj.Colliding(npc.HitBox))
            //        {
            //            proj.OnHitNPC(npc);
            //            MainCharacter.OnUnderAttack(npc);
            //        }
            //    }

            //    if (proj.Colliding(MainCharacter.HitBox))
            //    {
            //        proj.OnHitCharacter(MainCharacter);
            //        MainCharacter.OnUnderAttack(proj);
            //    }
            //}

            foreach (Dusts dust in Instance.Dusts)
            {
                dust.OnUpdate();
                dust.OnDraw();
            }
            
        }

        public void LateUpdate()
        {
            foreach (Character character in Instance.Characters)
            {
                character.OnLateUpdate();
            }

            foreach (NPC npc in Instance.NPCs)
            {
                npc.OnLateUpdate();
            }

            foreach (Projectile proj in Instance.Projectiles)
            {
                proj.OnLateUpdate();
            }

            foreach (Dusts dust in Instance.Dusts)
            {
                dust.OnLateUpdate();
            }
            #region 列表自检 删除
            for (int i = Instance.Projectiles.Count - 1; i >= 0; i--)
            {
                if (!Projectiles[i].IsActive)
                {
                    Destroy(Projectiles[i].gameObject);
                    Projectiles.RemoveAt(i);
                }
            }

            for (int i = Instance.NPCs.Count - 1; i >= 0; i--)
            {
                if (!NPCs[i].IsActive)
                {
                    Destroy(NPCs[i].gameObject);
                    NPCs.RemoveAt(i);
                }
            }
            for (int i = Instance.Dusts.Count - 1; i >= 0; i--)
            {
                if (!Dusts[i].IsActive)
                {
                    Destroy(Dusts[i].gameObject);
                    Dusts.RemoveAt(i);
                }
            } 
            #endregion
        }
        /// <summary>
        /// 新的一天！！ 每天开始运行的方法 主要用于提供随机事件
        /// </summary>
        public void NewDay()
        {
            
        }
    }

}