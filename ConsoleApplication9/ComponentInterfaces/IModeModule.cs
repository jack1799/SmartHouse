using System;

namespace ConsoleApplication9
{
    public interface IModeModule
    {
        Enum CurrentMode { get; set; }

        bool SetMode(string argument);
    }
}