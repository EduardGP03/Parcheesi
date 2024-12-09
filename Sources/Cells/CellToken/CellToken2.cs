class CellToken0 : CellToken
{
    public CellToken0()
    {

    }

    public override void ActivateEffect(Token token)
    {
        token.ProtectedToken = true;
    }
}