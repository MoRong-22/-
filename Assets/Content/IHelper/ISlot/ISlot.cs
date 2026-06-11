namespace Content.IHelper.ISlot
{
    /// <summary>
    /// 给饰品提供的接口
    /// </summary>
    public interface ISlot
    {
        /// <summary>
        /// 饰品更新
        /// </summary>
        /// <param name="character">角色</param>
        void SlotUpdate(Character character);
        /// <summary>
        /// 玩家被攻击
        /// </summary>
        /// <param name="character">角色</param>
        void ByHit(Character character);
        /// <summary>
        /// 生命减少
        /// </summary>
        /// <param name="character">角色</param>
        void HealthDrop(Character character);
        /// <summary>
        /// 生命增加
        /// </summary>
        /// <param name="character">角色</param>
        void HealthAdd(Character character);
        /// <summary>
        /// 攻击NPC
        /// </summary>
        /// <param name="character">角色</param>
        /// <param name="target">被攻击者</param>
        void HitNPC(Character character, NPC target);
        /// <summary>
        /// 被攻击
        /// </summary>
        /// <param name="character">角色</param>
        /// <param name="target">攻击者</param>
        void ByHit(Character character, NPC target);
        /// <summary>
        /// 被攻击
        /// </summary>
        /// <param name="character">角色</param>
        /// <param name="projectile">弹幕</param>
        void ByHit(Character character,Projectile projectile);
    }
}