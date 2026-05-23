namespace Content.IHelper
{
    public interface IStats
    {
        float MaxHealth { get; set; }
        float CurrentHealth { get; set; }
        float HealthRegen { get; set; }
        float MaxMana { get; set; }
        float CurrentMana { get; set; }
        float ManaRegen { get; set; }
        float PhysicalDefense { get; set; }
        float MagicDefense { get; set; }
        float DamageReduce { get; set; }
        bool IsActive { get; }
    }
}
