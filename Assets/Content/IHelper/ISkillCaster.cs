using System.Collections.Generic;
using AboutDamage;
using Content;

namespace Content.IHelper
{
    public interface ISkillCaster
    {
        Skill[] Skills { get; set; }
        Skill CurrentSkill { get; set; }
        bool CanUseSkill();
        void UseSkill();
    }
}
