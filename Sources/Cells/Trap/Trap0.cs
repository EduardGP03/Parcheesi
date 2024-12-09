class Trap0 : Trap
{
    (int, int) Modifier;

    public Trap0((int, int) modifier)
    {
        Modifier = modifier;
    }

    public override void ActivateEffect(Token token)
    {
        token.Speed.AddModifiier(Modifier.Item1, Modifier.Item2);
    }
}