
public class Speed
{
    public int baseValue{get; private set;}
    public Dictionary<int, int> ModifierswithDuration;

    public Speed()
    {
        ModifierswithDuration = new();
    }

   
    public void AddModifiier(int mod, int duration) => this.ModifierswithDuration.Add(mod, duration);

    public void UpdateModifers()
    {
        foreach (var mod in ModifierswithDuration.Keys)
        {
            ModifierswithDuration[mod] -= 1;
            if (ModifierswithDuration[mod] <= 0)
                ModifierswithDuration.Remove(mod);

        }
    }


}