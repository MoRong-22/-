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
            instance.Map.MainCharacter.OnUpdate();
            instance.Map.MainCharacter.OnDraw();
            foreach(Character character in instance.Map.SecondaryCharacter)
            {
                character.OnUpdate();
                character.OnDraw();
            }

            foreach (NPC npc in instance.NPCs)
            {
                
            }

            foreach (Projectile proj in instance.Projectiles)
            {
                proj.OnUpdate();
                proj.OnFixedUpdate();
                if (proj.PreDraw())
                {
                    proj.Draw();
                    proj.PostDraw();
                }

                foreach (NPC npc in instance.NPCs)
                {
                    if (proj.Colliding(npc.HitBox))
                    {
                        proj.OnHitNPC(npc);
                    }
                }

                if (proj.Colliding(MainCharacter.HitBox))
                {
                    proj.OnHitCharacter(MainCharacter);
                    MainCharacter.OnUnderAttack(proj);
                }
            }
        }
    }

}