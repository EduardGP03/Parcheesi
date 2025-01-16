public abstract class Ability 
{
   public string Name { get; set; }
   public int CooldownTime { get; set; }

   protected Ability(string name, int cooldownTime) 
   {
       Name = name;
       CooldownTime = cooldownTime;
   }

   public abstract void Activate(Token token); // Método que debe ser implementado por las habilidades concretas.
}

public class SpeedBoostAbility : Ability 
{
   public SpeedBoostAbility() : base("Speed Boost", 3) {}

   public override void Activate(Token token) 
   {
       token.Speed.AddModifier(2, 1); // Aumenta la velocidad por un turno.
       Console.WriteLine($"{token.TokenFaction} ha activado {Name}!");
   }
}
