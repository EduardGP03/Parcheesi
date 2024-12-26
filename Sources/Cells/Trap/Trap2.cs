class Trap2 : Trap
{
    public Trap2()
    {

    }

    public override void ActivateEffect(Token token)
    {
        token.Position = token.BasePosition;
    }
}