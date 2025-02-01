using Godot;

class Trap1 : Trap
{
    int cantSteps;
    Cell[] ArrayCell;
    public Trap1(Cell[] arrayCell)
    {
        ArrayCell = arrayCell;
    }

    public override void ActivateEffect(Token token)
    {
        token.Move(ArrayCell, cantSteps);
        GD.Print("Trap1");
    }
}