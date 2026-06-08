using Content.IHelper.ISlot;
using UnityEngine;

namespace Content
{
    public abstract class Slots : ScriptableObject,ISlot
    {
        #region 饰品接口
        public virtual void ByHit(Character character){}
        public virtual void HealthAdd(Character character){}
        public virtual void HealthDrop(Character character){}
        public virtual void SlotUpdate(Character character){}
        public virtual void HitNPC(Character character, NPC target){}
        #endregion
    }
}