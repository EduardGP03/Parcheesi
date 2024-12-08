class Wall : Cell
{
    int CoolDown;
    bool IsActive;
    private int Time;

    public Wall(int time, Cell previous, Cell next) : base(previous, next)
    {
        IsActive = true;
        Time = time;
        CoolDown = 0;
    }

    public override void Efect(Token token)
    {
        if (Wall.IsActive)
        {
            IsActive = false;
            CoolDown = Time;
        }
    }
}