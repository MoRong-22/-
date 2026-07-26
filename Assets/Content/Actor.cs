using System;
using System.Collections.Generic;
using AboutCollide;
using AboutDamage;
using Content.IHelper;
using UnityEngine;

namespace Content
{
    public abstract class Actor : MonoBehaviour,IKill,IRare,IName,ISetting,ILevelable, IStats, ISkillCaster, IDamageable,IStatusEffectCaster
    {
        #region 等级控制
        public GameObject instance;
        public int CurrentLevel { get; set; }
        public float MaxLevelProgress { get; set; }
        public float LevelProgress { get; set; }
        public virtual void WhenLevelUp(){}
        public void LevelUp()
        {
            while (LevelProgress >= MaxLevelProgress)
            {
                LevelProgress -= MaxLevelProgress;
                CurrentLevel++;
                MaxLevelProgress = GetLevelNeedProgress(CurrentLevel);
                WhenLevelUp();
            }
        }

        private float GetLevelNeedProgress(int currentLevel)
        {
            return 100 + currentLevel * 25;
        }
        #endregion

        #region 死亡接口
        public virtual bool CanKill() => true;
        public virtual void Kill(){}

        public virtual void OnKill(){}
        #endregion
        #region 价值接口
        public Rare Rare {get;set;}
        public float Coin { get; set; }
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
        #endregion

        #region 状态附着控制
        
        public List<StatusEffect> Effects { get; set; }

        public virtual bool CanUpdateEffect(StatusEffect effect) => true;

        #endregion

        #region 伤害控制

        public Damage_class Damage_class { get; set; }
        public virtual bool CanUnderAttack(Projectile projectile) => true;
        public virtual void UnderAttack(Projectile projectile) {}
        public bool CanUnderAttack(Character character) => true;
        public void UnderAttack(Character character){}
        public bool CanUnderAttack(NPC npc) => true;
        public void UnderAttack(NPC npc){}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="npc"></param>
        /// <param name="damageAmount"></param>
        public virtual void TakeDamage(NPC npc,Damage_class damageAmount)
        {
            CurrentHealth -= damageAmount.GetDamage(npc) * (1 - DamageReduce / 100f);
            OnKill();
        }

        public virtual void TakeDamage(Character character, Damage_class damageAmount)
        {
            CurrentHealth -= damageAmount.GetDamage(character) * (1 - DamageReduce / 100f);
            OnKill();
        }
        public virtual void OnHitNPC(NPC npc){}
        
        public virtual void OnHitCharacter(Character character){}
        #endregion

        #region 名字
        public string Name { get; set; }
        #endregion

        #region 移动控制

        //public Vector3 Center { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Velocity { get; set; }
        public float Speed { get; set; }
        #endregion

        //#region 碰撞控制
        //public HitBox HitBox { get; set; }

        //public virtual bool Colliding(HitBox targetBox)
        //{
        //    return targetBox.Intersects(HitBox);
        //}

        //public virtual void ModifyHitBox(HitBox box){}

        //#endregion

        #region 绘制所需

        public virtual void Draw(){}
        public virtual bool PreDraw() => false;
        public virtual void PostDraw(){}

        public Color MainColor { get; set; }
        public Color OutlineColor { get; set; }
        public float OutlineWidth { get; set; }
        public bool EnableOutline { get; set; }
        public Texture2D Texture { get; set; }
        #endregion

        //#region AI控制
        //public virtual void AI() { }
        //#endregion

        #region 值设置

        public virtual void SetDefault()
        {
            Skills = new Skill[3];
            Effects = new List<StatusEffect>();
        }
        public virtual void Modify(){}
        #endregion
    }
}
