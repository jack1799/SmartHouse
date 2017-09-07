namespace ConsoleApplication9
{
    public interface IChannelDevice : IParamDevice
    {
        IChannelModule Channel { get; set; }
    }
}