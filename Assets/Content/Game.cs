using System.Collections.Generic;
using Content;
using Content.Drawing;
using UnityEngine;

namespace  Content
{
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

        
        void Update()
        {
            MainCharacter.OnUpdate();
            MainCharacter.OnDraw();
            foreach(Character character in instance.Map.SecondaryCharacter)
            {
                character.OnUpdate();
                character.OnDraw();
            }

            foreach (NPC npc in instance.NPCs)
            {
                npc.OnUpdate();
                npc.OnDraw();
                if (npc.Colliding(MainCharacter.HitBox))
                {
                    npc.OnHitNPC(npc);
                    MainCharacter.OnUnderAttack(npc);
                }
            }

            foreach (Projectile proj in instance.Projectiles)
            {
                proj.OnFixedUpdate();
                proj.OnUpdate();
                proj.OnLateUpdate();
                proj.OnDraw();

                foreach (NPC npc in instance.NPCs)
                {
                    if (proj.Colliding(npc.HitBox))
                    {
                        proj.OnHitCharacter(MainCharacter);
                        MainCharacter.OnUnderAttack(npc);
                    }
                }

                if (proj.Colliding(MainCharacter.HitBox))
                {
                    proj.OnHitCharacter(MainCharacter);
                    MainCharacter.OnUnderAttack(proj);
                }
            }

            foreach (Dusts dust in instance.Dusts)
            {
                dust.OnFixedUpdate();
                dust.OnUpdate();
                dust.OnLateUpdate();
                dust.OnDraw();
            }
            for (int i = instance.Projectiles.Count - 1; i >= 0; i--)
            {
                if (!Projectiles[i].IsActive)
                {
                    Destroy(Projectiles[i].gameObject);
                    Projectiles.RemoveAt(i);
                }
            }

            for (int i = instance.NPCs.Count - 1; i >= 0; i--)
            {
                if (!NPCs[i].IsActive)
                {
                    Destroy(NPCs[i].gameObject);
                    NPCs.RemoveAt(i);
                }
            }
            for (int i = instance.Projectiles.Count - 1; i >= 0; i--)
            {
                if (!Projectiles[i].IsActive)
                {
                    Destroy(Projectiles[i].gameObject);
                    Projectiles.RemoveAt(i);
                }
            }
            for (int i = instance.Dusts.Count - 1; i >= 0; i--)
            {
                if (!Dusts[i].IsActive)
                {
                    Destroy(Dusts[i].gameObject);
                    Dusts.RemoveAt(i);
                }
            }
            
        }
    }

}