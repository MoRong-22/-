namespace Content.Skills.FirstCharacter
{
    public class Skill_one : Skill
    {
        public Skill_one(string Name, string description, float damage, int maxCharges, float countRangeTimeMax, float manaCost, float cooldownMax, int currentCharges = 1) : base(Name, description, damage, maxCharges, countRangeTimeMax, manaCost, cooldownMax, currentCharges)
        {
        }
    }
}