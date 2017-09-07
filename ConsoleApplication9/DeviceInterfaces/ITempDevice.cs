namespace ConsoleApplication9
{
    public interface ITempDevice : IParamDevice
    {
        ITempModule Temp { get; set; }
    }
}