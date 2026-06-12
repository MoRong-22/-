namespace Content.IHelper
{
    public interface IUnderAttack
    {
        /// <summary>
        /// 受到攻击
        /// </summary>
        /// <param name="projectile">弹幕</param>
        void OnUnderAttack(Projectile projectile);
        /// <summary>
        /// 受到攻击
        /// </summary>
        /// <param name="npc">npc</param>
        void OnUnderAttack(NPC npc);
    }
}