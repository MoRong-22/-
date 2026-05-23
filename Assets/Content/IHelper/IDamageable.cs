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
        /// 受到伤害
        /// </summary>
        /// <param name="damageAmount">伤害值</param>
        void TakeDamage(Damage_class damageAmount);

        bool CanUnderAttack();
        /// <summary>
        /// 受到攻击
        /// </summary>
        void UnderAttack();
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
