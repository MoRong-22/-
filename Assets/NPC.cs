using UnityEngine;

public abstract class NPC
{
    public bool IsFriend { get; private set; }
    public bool IsActived { get; private set; }
    public int ID { get; private set; }
    public string Name { get; private set; }
    public float Damage { get; private set; }
    public float MaxLife {  get; private set; }
    public float StatLife { get; private set; }
    public Buff[] buffs;
}
