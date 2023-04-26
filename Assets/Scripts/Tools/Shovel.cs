public class Shovel : Tool
{
    public override Types Type { get; protected set; }
    private void Awake()
    {
        Type = Types.Shovel;
    }
}
