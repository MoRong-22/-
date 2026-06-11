using AboutDamage;

namespace Content.IHelper
{
    /// <summary>
    /// 伤害可用接口
    /// </summary>
    public interface IDamageable
    {
        Damage_class Damage_class { get; set; }
        /// <summary>
        /// NPC受到伤害
        /// </summary>
        /// <param name="npc">被伤害的对象</param>
        /// <param name="damageAmount">伤害值</param>
        void TakeDamage(NPC npc,Damage_class damageAmount);
        /// <summary>
        /// 角色受到伤害
        /// </summary>
        /// <param name="character">被伤害的对象</param>
        /// <param name="damageAmount">伤害值</param>
        void TakeDamage(Character character,Damage_class damageAmount);
        /// <summary>
        /// 能否受到攻击
        /// </summary>
        /// <param name="projectile">弹幕</param>
        /// <returns></returns>
        bool CanUnderAttack(Projectile projectile);
        /// <summary>
        /// 受到攻击
        /// </summary>
        /// <param name="projectile">弹幕</param>
        void UnderAttack(Projectile projectile);
        /// <summary>
        /// 能否受到攻击
        /// </summary>
        /// <param name="character">角色</param>
        /// <returns></returns>
        bool CanUnderAttack(Character character);
        /// <summary>
        /// 受到攻击
        /// </summary>
        /// <param name="character">角色</param>
        void UnderAttack(Character character);
        /// <summary>
        /// 能否受到攻击
        /// </summary>
        /// <param name="npc">NPC</param>
        /// <returns></returns>
        bool CanUnderAttack(NPC npc);
        /// <summary>
        /// 能否受到攻击
        /// </summary>
        /// <param name="npc"></param>
        void UnderAttack(NPC npc);
        /// <summary>
        /// 攻击NPC
        /// </summary>
        /// <param name="npc">NPC</param>
        void OnHitNPC(NPC npc);
        /// <summary>
        /// 攻击角色
        /// </summary>
        /// <param name="character">角色</param>
        void OnHitCharacter(Character character);
    }
}
