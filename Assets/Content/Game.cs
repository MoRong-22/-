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

        #endregion

        void Start()
        {
            
        }

        
        void Update()
        {
            SpriteDrawer.Draw(Texture2D.whiteTexture,new Vector3(1,1,1),new Vector2(1,1),Color.white);
            foreach(Character character in instance.Characters)
            {
                character.AI();
                if(character.PreDraw())
                {
                    character.Draw();
                    character.PostDraw();
                }
            }
        }
    }

}