using System.Collections.Generic;
using AboutCollide;
using AboutDamage;
using Content.IHelper;
using UnityEngine;

namespace Content
{
    public abstract class Projectile : MonoBehaviour,IUpdateable, IMovable,IDamageable,IColliding,IDrawHelper
    {
        public GameObject projectilePrefab;
        public virtual void SetDefault(Damage_class damageClass,Vector3 position, Quaternion rotation, Vector3 velocity, float speed){}
        #region 移动控制

        public Vector3 Center { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Velocity { get; set; }
        public float Speed { get; set; }
        #endregion

        #region 更新控制

        public float TimeLeft { get; set; }
        public float MaxTimeLeft { get; set; }
        public bool IsActive => TimeLeft > 0;

        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }

        #endregion

        #region 伤害控制

        public Damage_class Damage_class { get; set; }
        public virtual bool CanUnderAttack()
        {
            throw new System.NotImplementedException();
        }

        public virtual void UnderAttack(){}
        public virtual void TakeDamage(Damage_class damageAmount){}
        public virtual void OnHitNPC(NPC npc){}
        
        public virtual void OnHitCharacter(Character character){}
        #endregion

        #region 碰撞控制
        public void ModifyHitBox(HitBox box){}
        public HitBox HitBox { get; set; }
        public virtual bool Colliding(HitBox targetBox)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region 绘制控制

        public float OutlineWidth { get; set; }
        public bool EnableOutline { get; set; }
        public Color OutlineColor { get; set; }
        public Color MainColor { get; set; }
        public virtual void Draw(){}
        public virtual bool PreDraw() => true;
        public virtual void PostDraw(){}
        #endregion
        
        
        
        /// <summary>
        /// 创建弹幕：new 一个空物体 + AddComponent，加入对象池
        /// 视觉由子类在 Awake/Start 里自己处理
        /// </summary>
        public static T NewProjectile<T>(Vector3 position, Quaternion rotation,
            Vector3 velocity, float speed, Damage_class damageClass) where T : Projectile
        {
            GameObject obj = new(typeof(T).Name);
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            T proj = obj.AddComponent<T>();
            proj.SetDefault(damageClass, position, rotation, velocity, speed);
            Game.instance.Projectiles.Add(proj);
            return proj;
        }
    }
}