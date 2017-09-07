using System;

namespace ConsoleApplication9
{
    [Serializable]
    public class BlenderMode : IModeModule
    {
        public Enum CurrentMode { get; set; } = new BlenderModes();
        
        public BlenderMode(BlenderModes mode)
        {
            CurrentMode = mode;
        }

        public bool SetMode(string argument)
        {
            switch (argument.ToLower())
            {
                case "normal":
                    CurrentMode = BlenderModes.Normal;
                    return true;
                case "super":
                    CurrentMode = BlenderModes.Super;
                    return true;
                default:
                    return false;
            }
        }
    }
}