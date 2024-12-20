class Wall : Cell
{
    int CoolDown;
    private bool IsActive;
    public bool IsUsed{get; private set;}
    private int Time;
    private Tuple<int,int> modifier;

    public Wall(int time,Tuple<int,int> modifier)
    {
        IsActive = true;
        Time = time;
        CoolDown = 0;
        IsUsed=false;
        this.modifier= modifier;
    }

    public override void ActivateEffect(Token token)
    {
        if (IsActive)
        {
            IsActive = false;
            CoolDown = Time;
            IsUsed = true;
            token.Speed.AddModifiier(modifier.Item1,modifier.Item2);
        }
        else
        {
            IsUsed=false;
        }
    }
    public void UpdateState()
    {
        if(CoolDown > 0) CoolDown--;
        else 
        {
            CoolDown=0;
            IsActive=true;
        }
    }
}