using UnityEngine;
    /// <summary>
    /// 玩家实体，拥有装备系统
    /// </summary>
    public class AllyEntity : CharacterBase
    {
        /// <summary>
        /// 唯一装备槽，玩家仅能穿戴一件装备
        /// </summary>
        public Slot EquipSlot { get; private set; }

        public AllyEntity()
        {
            EquipSlot = new Slot();
        }

        //重写属性，叠加装备加成
        public override int MaxHealth
        {
            get
            {
                EquipSlot.GetBonus(out int hpBonus, out _, out _);
                return baseMaxHealth + hpBonus;
            }
        }
        public override int Attack
        {
            get
            {
                EquipSlot.GetBonus(out _, out int atkBonus, out _);
                return baseAttack + atkBonus;
            }
        }
        public override int Defense
        {
            get
            {
                EquipSlot.GetBonus(out _, out _, out int defBonus);
                return baseDefense + defBonus;
            }
        }
        /// <summary>
        /// 尝试装备道具，自动替换旧装备
        /// </summary>
        /// <param name="item">想要穿戴的装备</param>
        /// <returns>装备成功返回true</returns>
        public bool TryEquipItem(Equipment item)
        {
            if (item == null) return false;
            //把当前穿戴的旧装备卸下
            Equipment oldEquip = EquipSlot.UnEquip();
            if (oldEquip != null)
            {
                //旧装备放回【全局公共背包】
                GlobalPlayerInventory.Instance.Inventory.Add(oldEquip);
            }

            //穿戴新装备
            EquipSlot.Equip(item);
            //从全局背包移除这件装备
            GlobalPlayerInventory.Instance.Inventory.Remove(item);
            return true;
        }
        /// <summary>
        /// 卸下当前装备，放回全局背包
        /// </summary>
        public Equipment UnEquipItem()
        {
            Equipment item = EquipSlot.UnEquip();
            if (item != null)
            {
                GlobalPlayerInventory.Instance.Inventory.Add(item);
            }
            return item;
        }
        /// <summary>
        /// 玩家复活，重置装备状态
        /// </summary>
        public override void InitCharacter()
        {
            base.InitCharacter();
            //复活卸下装备，清空装备槽（可选，根据你的游戏设计决定要不要注释）
            //EquipSlot.UnEquip();
        }

        protected override void OnDeath()
        {
            Debug.Log("玩家死亡，触发游戏结束");
        }
    }