namespace Content
{
    public interface IModify
    {
        void ModifyDayEvent(DayEvent dayEvent);
        void ModifyCharacter(Character character);
        void ModifyNPC(NPC npc);
        void ModifyProjectile(Projectile projectile);
    }
}