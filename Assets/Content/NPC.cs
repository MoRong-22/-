using Content.IHelper;

namespace Content
{
    public abstract class NPC : Actor,IRunF,IUnderAttack
    {
        public override void SetDefault()
        {
            CurrentLevel = 1;
            base.SetDefault();
        }
        public void OnUpdate()
        {
            //AI();
            foreach (var effect in Effects)
                if(CanUpdateEffect(effect))
                    effect.Update(this);
        }
        public void OnFixedUpdate(){}
        public void OnLateUpdate(){}
        public void OnUnderAttack(Projectile projectile)
        {
            UnderAttack(projectile);
            TakeDamage(this,projectile.Damage_class);
        }

        public void OnUnderAttack(NPC npc)
        {
            UnderAttack(npc);
            TakeDamage(this,npc.Damage_class);
        }

        public override void OnKill()
        {
            if (!IsActive&&CanKill())
            {
                Kill();
                Game.Instance.Settlement.KillRecord(Name,1);
            }
        }

        public void OnDraw()
        {
            if (PreDraw())
            {
                Draw();
                PostDraw();
            }
        }
    }
}