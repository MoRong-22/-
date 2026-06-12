using System;
using System.Linq;
using AboutCollide;
using AboutDamage;
using UnityEngine;

namespace Content.Projectiles.FirstCharacter
{
    public class ArrayFlag : Projectile
    {
        public bool isLink = false;
        public ArrayFlag linkFlag;
        public ArrayFlag byLinkFlag;
        public static float MaxLinkDistance = 20f;
        public override void SetDefault(Damage_class damageClass, Vector3 position, Quaternion rotation,
            Vector3 velocity, float speed)
        {
            this.Damage_class = damageClass;
            this.Center = position;
            this.Rotation = rotation;
            this.Velocity = velocity;
            this.Speed = speed;
        }

        public override void Update()
        {
            // 未链接时重连所有旗子
            if (!isLink)
            {
                foreach (var proj in Game.instance.Projectiles)
                {
                    if (proj is ArrayFlag flag)
                        flag.CheckLink();
                }
            }
        }

        public override bool Colliding(HitBox targetBox)
        {
            return base.Colliding(targetBox);
        }

        /// <summary>
        /// 链接最近的 2 个同类旗子
        /// </summary>
        public void CheckLink()
        {
            var flags = Game.instance.Projectiles
                .OfType<ArrayFlag>()
                .Where(f => f != this)
                .OrderBy(f => Vector3.Distance(this.Center, f.Center))
                .Take(2);
            isLink = true;
            linkFlag = flags.FirstOrDefault();
            byLinkFlag = flags.Skip(1).FirstOrDefault();
        }
    }
}