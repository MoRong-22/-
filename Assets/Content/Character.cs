using System;
using System.Collections.Generic;
//TODO : 需要补全按键检测 整体运行逻辑
namespace Content
{
    public abstract class Character : Actor
    {
        public List<Props>  Props { get; set; }
        public List<Slots>  Slots { get; set; }
        public override void SetDefault()
        {
            CurrentLevel = 1;
            
            Slots = new List<Slots>();
            Props = new List<Props>();
            base.SetDefault();
        }
        public void OnUpdate()
        {
            AI();
            foreach (var slot in Slots)
                slot.SlotUpdate(this);
            foreach (var skill in Skills)
                skill.Update(this);
            foreach (var effect in Effects)
                if(CanUpdateEffect(effect))
                    effect.Update(this);
        }

        public void OnUnderAttack(Projectile projectile)
        {
            UnderAttack(projectile);
            foreach(var slot in Slots)
                slot.ByHit(this, projectile);
            TakeDamage(this,projectile.Damage_class);
        }

        public void OnUnderAttack(NPC npc)
        {
            UnderAttack(npc);
            foreach(var slot in Slots)
                slot.ByHit(this, npc);
            TakeDamage(this,npc.Damage_class);
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
