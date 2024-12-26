public abstract class Ability
{
    public string Name { get; set; }
    public int CooldownTime { get; set; }

    public Ability(string name, int cooldownTime)
    {
        Name = name;
        CooldownTime = cooldownTime;
    }
}

// no he hecho nada

