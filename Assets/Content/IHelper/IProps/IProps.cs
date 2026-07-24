using System;

namespace Content.IHelper.IProps
{
    public interface IProps
    {
        void OnUse(Character character);
        bool CanUse(Character character);
        void Use(Character character);
    }
}