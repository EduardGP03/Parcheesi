class CellToken2 : CellToken
{
    public CellToken2()
    {

    }

    public override void ActivateEffect(Token token)
    {
        token.ProtectedToken = true;
    }
}