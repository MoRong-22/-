using AboutDamage;

namespace Content.Characters
{
    public class FirstCharacter : Character
    {
        public override void SetDefault()
        {
            Name = "First";
            Damage_class = new Damage_class(Damage_enum.Magic,10,0,10,0,0,10,2);
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
            MaxMana = 100;
            CurrentMana = MaxMana;
            PhysicalDefense = 87;
            MagicDefense = 87;
            DamageReduce = 10;
            Speed = 10;
            base.SetDefault();
        }
    }
}