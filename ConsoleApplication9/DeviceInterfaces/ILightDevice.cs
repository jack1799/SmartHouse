namespace ConsoleApplication9
{
    public interface ILightDevice : IParamDevice
    {
        ILightModule Light { get; set; }
    }
}