using Content.IHelper;

namespace Content
{
    public abstract class NPC : Actor, IAIControllable 
    {
        public virtual void AI() { }
    }
}