class CellToken0: CellToken
{
    (int, int) Modifier;

    public CellToken0((int, int) modifier)
    {
        Modifier = modifier;
    }

    public override void ActivateEffect(Token token)
    {
        token.Speed.AddModifiier(Modifier.Item1, Modifier.Item2);
    }
}