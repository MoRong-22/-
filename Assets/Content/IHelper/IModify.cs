namespace Content.IHelper
{
    /// <summary>
    /// 修改接口
    /// </summary>
    public interface IModify
    {
        /// <summary>
        /// 修改事件
        /// </summary>
        /// <param name="dayEvent"></param>
        void ModifyDayEvent(DayEvent dayEvent);
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="character"></param>
        void ModifyCharacter(Character character);
        /// <summary>
        /// 修改NPC
        /// </summary>
        /// <param name="npc"></param>
        void ModifyNPC(NPC npc);
        /// <summary>
        /// 修改弹幕
        /// </summary>
        /// <param name="projectile"></param>
        void ModifyProjectile(Projectile projectile);
    }
}