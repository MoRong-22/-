using System.Collections.Generic;
using AboutDamage;
using Content.IHelper;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = System.Numerics.Vector3;

namespace Content
{
    public abstract class Actor : ILevelable, IStats, ISkillCaster, IDamageable, IMovable
    {
        #region ILevelable

        public int MaxLevel { get; set; }
        public int CurrentLevel { get; set; }
        public float MaxLevelProgress { get; set; }
        public float LevelProgress { get; set; }

        public virtual void LevelUp()
        {
            if (CurrentLevel < MaxLevel)
                CurrentLevel++;
        }

        #endregion

        #region IStats

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

        #region ISkillCaster

        public Skill[] Skills { get; set; }
        public Skill CurrentSkill { get; set; }
        public List<StatusEffect> Effects { get; set; }

        public virtual bool CanUseSkill()
        {
            return CurrentMana > CurrentSkill.manaCost;
        }

        public virtual void UseSkill() { }

        #endregion

        #region IDamageable

        public virtual void TakeDamage(float damageAmount) { }
        public virtual void UnderAttack() { }

        #endregion

        #region IMovable

        public Vector3 Center { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Velocity { get; set; }

        #endregion
    }
}
