namespace ConsoleApplication9
{
    public interface IModeDevice
    {
        IModeModule Mode { get; set; }

        bool SetMode(string Argument);
    }
}