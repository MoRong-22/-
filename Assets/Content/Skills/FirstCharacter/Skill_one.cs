using UnityEngine.InputSystem;

namespace Content.Skills.FirstCharacter
{
    public class Skill_one : Skill
    {
        public Skill_one() : base("Skill_one","",0,0,0,0,0,new KeyBind(Keyboard.current.zKey,"第一个技能 "))
        {
            
        }
    }
}