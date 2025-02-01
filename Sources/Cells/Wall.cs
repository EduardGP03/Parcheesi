using Godot;
class Wall : Cell
{
    int CoolDown;
    private bool IsActive;
    public bool IsUsed { get; private set; }
    private int Time;
    private (int, int) modifier;

    public Wall(int time, (int, int) modifier)
    {
        IsActive = true;
        Time = time;
        CoolDown = 0;
        IsUsed = false;
        this.modifier = modifier;
    }

    public override void ActivateEffect(Token token)
    {
        if (IsActive)
        {
            IsActive = false;
            CoolDown = Time;
            IsUsed = true;
            token.Speed.AddModifier(modifier.Item1, modifier.Item2);
        }

        else
        {
            IsUsed = false;
        }

    GD.Print("wall");
    }
    
    public void UpdateState()
    {
        if (CoolDown > 0)
            CoolDown--;

        else
        {
            CoolDown = 0; 
            IsActive = true;
        }
    }
}