public class Initial
{
    public int Exit { get; set;}
    public int Entry {get; set;}
    public Faction Color = new Faction();

    public Initial(int exit, int entry, Faction color)
    {
        Exit = exit;
        Entry = entry;
        Color = color;
    }
}