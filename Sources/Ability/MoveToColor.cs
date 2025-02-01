public class MoveToColor : Ability
{
    public int ubication { get; set; }

    public MoveToColor() : base("Move", 5)
    {

    }

    public override void Activate(Player player, Token token)
    {
        (int distance, int position) tem = (-40, -1);

        foreach (var element in player.Tokens)
        {
            if (element.Position > player.Start.Entry)
            {
                if (tem.distance < element.Position - 40)
                {
                    tem.distance = element.Position - 40;
                    tem.position = element.Position;
                }
            }

            else
            {
                if (tem.distance < player.Start.Entry - element.Position)
                {
                    tem.distance = player.Start.Entry - element.Position;
                    tem.position = element.Position;
                }
            }
        }

        token.Position = tem.position;
    }
}