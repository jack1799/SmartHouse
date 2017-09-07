using System;

namespace ConsoleApplication9
{
    [Serializable]
    public class TVMode : IModeModule
    {
        public Enum CurrentMode { get; set; } = new TVModes();

        public TVMode(TVModes mode)
        {
            CurrentMode = mode;
        }

        public bool SetMode(string argument)
        {
            switch (argument.ToLower())
            {
                case "normal":
                    CurrentMode = TVModes.Normal;
                    return true;
                case "intensified":
                    CurrentMode = TVModes.Intensified;
                    return true;
                case "super":
                    CurrentMode = TVModes.Super;
                    return true;
                default:
                    return false;
            }
        }
    }
}