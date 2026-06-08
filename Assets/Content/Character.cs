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
        }
        public virtual void Update()
        {
            AI();
            foreach (var slot in Slots)
                slot.SlotUpdate(this);
        }
    }
}
