using System;
using System.Collections.Generic;

public class Stop : Ability
{
    public Cell[] Cells { get; set; }
    
    public Stop(Cell[] cells) : base("Stop", 3)
    {
        Cells = cells;
    }
   
    public override void Activate(Player Player, Token token)
    {
        List<Token> value = DistanceOfAbility(Cells, token);

        if (value != null)
            StopToken(DistanceOfAbility(Cells, token));

        else
            Console.WriteLine("no se pudo ejecutar la habilidad ");
    }

    private void StopToken(List<Token> tokens)
    {
        if (!Chield(tokens))
            tokens[0].Speed.AddModifier(0, 2);

        else
            tokens[0].ProtectedEffect = false;
    }
}