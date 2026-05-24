using AboutCollide;
using AboutDamage;
using Content.IHelper;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = System.Numerics.Vector3;

namespace Content
{
    public abstract class Projectile : IUpdateable, IMovable,IDamageable,IColliding
    {
        #region 移动控制

        public Vector3 Center { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Velocity { get; set; }

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
        public bool Colliding(HitBox targetBox)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}