using UnityEngine;

public abstract class Character
{
    public float MaxLife { get; private set; }
    public float StatLife { get;set; }
    public float ManaMax { get; private set; }
    public float StatMana { get; set; }
    public Skill[] Skills { get; private set; }
}
