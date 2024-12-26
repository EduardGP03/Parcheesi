class CellToken1 : CellToken
{
    int cantSteps;
    Cell[] ArrayCell;
    public CellToken1(Cell[] arrayCell)
    {
        ArrayCell = arrayCell;
    }

    public override void ActivateEffect(Token token)
    {
        token.Move(ArrayCell, cantSteps);
    }
}