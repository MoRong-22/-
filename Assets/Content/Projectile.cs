using System;
using System.Collections.Generic;
using AboutCollide;
using AboutDamage;
using Content.IHelper;
using UnityEngine;

namespace Content
{
    public abstract class Projectile : LifeCycle,IDamageable,IColliding
    {
        public GameObject projectilePrefab;
        /// <summary>
        /// 设置默认值
        /// </summary>
        /// <param name="damageClass">伤害</param>
        /// <param name="position">位置</param>
        /// <param name="rotation">旋转</param>
        /// <param name="velocity">速度方向</param>
        /// <param name="speed">速度</param>
        public virtual void SetDefault(Damage_class damageClass,Vector3 position, Quaternion rotation, Vector3 velocity, float speed){}
        
        #region 伤害控制

        public Damage_class Damage_class { get; set; }
        public virtual bool CanUnderAttack(Projectile projectile) => true;
        public virtual void UnderAttack(Projectile projectile) {}
        public bool CanUnderAttack(Character character) => true;
        public void UnderAttack(Character character){}
        public bool CanUnderAttack(NPC npc) => true;
        public void UnderAttack(NPC npc){}
        public virtual void TakeDamage(NPC npc,Damage_class damageAmount){}
        public virtual void TakeDamage(Character character, Damage_class damageClass){}
        public virtual void OnHitNPC(NPC npc){}
        
        public virtual void OnHitCharacter(Character character){}
        #endregion

        #region 碰撞控制
        public void ModifyHitBox(HitBox box){}
        public HitBox HitBox { get; set; }
        public virtual bool Colliding(HitBox targetBox)
        {
            return targetBox.Intersects(HitBox);
        }
        #endregion
        
        
        
        
        
        
        /// <summary>
        /// 创建弹幕：new 一个空物体 + AddComponent，加入对象池
        /// 视觉由子类在 Awake/Start 里自己处理
        /// </summary>
        public static Func<T> NewProjectile<T>(Vector3 position, Quaternion rotation,
            Vector3 velocity, float speed, Damage_class damageClass) where T : Projectile
        {
            GameObject obj = new(typeof(T).Name);
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            T proj = obj.AddComponent<T>();
            proj.SetDefault(damageClass, position, rotation, velocity, speed);
            Game.Instance.Projectiles.Add(proj);
            return () => proj;
        }
    }
}