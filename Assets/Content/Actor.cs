using System.Collections.Generic;
using AboutCollide;
using AboutDamage;
using Content.IHelper;
using UnityEngine;
using static UnityEngine.Quaternion;
using static UnityEngine.Vector3;

namespace Content
{
    public abstract class Actor : MonoBehaviour,IName,ISetting,ILevelable, IStats, ISkillCaster, IDamageable, IMovable, IStatusEffectCaster, IColliding , IDrawHelper,IAIControllable
    {
        #region 等级控制

        public GameObject gameObject;
        public int MaxLevel
        {
            get
            {
                return MaxLevel;
            }
            set
            {
                MaxLevel = 10;
            }
        }
        public int CurrentLevel { get; set; }
        public float MaxLevelProgress { get; set; }
        public float LevelProgress { get; set; }

        public virtual void LevelUp()
        {
            if (CurrentLevel < MaxLevel)
                CurrentLevel++;
        }

        #endregion

        #region 状态控制

        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
        public float HealthRegen { get; set; }
        public float MaxMana { get; set; }
        public float CurrentMana { get; set; }
        public float ManaRegen { get; set; }
        public float PhysicalDefense { get; set; }
        public float MagicDefense { get; set; }
        public float DamageReduce { get; set; }
        public bool IsActive => CurrentHealth > 0;
        #endregion

        #region 技能控制

        public Skill[] Skills { get; set; }
        public Skill CurrentSkill { get; set; }

        public virtual bool CanUseSkill()
        {
            return CurrentMana > CurrentSkill.manaCost;
        }
        public virtual void UseSkill() {}
        #endregion

        #region 状态附着控制
        
        public List<StatusEffect> Effects { get; set; }

        public bool CanUpdateEffect(StatusEffect effect)
        {
            throw new System.NotImplementedException();
        }

        public virtual void UpdateEffect(StatusEffect effect)
        {
            throw new System.NotImplementedException();
        }

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

        #region 名字
        public string Name { get; set; }
        #endregion

        #region 移动控制

        public Vector3 Center { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Velocity { get; set; }
        public float Speed { get; set; }
        #endregion

        #region 碰撞控制
        public HitBox HitBox { get; set; }

        public bool Colliding(HitBox targetBox)
        {
            throw new System.NotImplementedException();
        }

        public void ModifyHitBox(HitBox box){}

        #endregion

        #region 绘制所需

        public virtual void Draw(){}
        public virtual bool PreDraw() => false;
        public virtual void PostDraw(){}

        public Color MainColor { get; set; }
        public Color OutlineColor { get; set; }
        public float OutlineWidth { get; set; }
        public bool EnableOutline { get; set; }
        #endregion

        #region AI控制
        public virtual void AI(){}
        #endregion

        #region 值设置

        public virtual void SetDefault(){}
        public virtual void Modify(){}
        #endregion
    }
}
