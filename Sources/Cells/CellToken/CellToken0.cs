using Godot;
class CellToken0: CellToken
{
    (int, int) Modifier;

    public CellToken0((int, int) modifier)
    {
        Modifier = modifier;
    }

    public override void ActivateEffect(Token token)
    {
        token.Speed.AddModifier(Modifier.Item1, Modifier.Item2);
        GD.Print("cellToken0");
    }
}