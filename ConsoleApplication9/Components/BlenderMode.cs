using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class BlenderMode : IMode
    {
        public BlenderMode() { }
        public BlenderMode(int mode)
        {
            CurrentMode = mode;
        }
        public int CurrentMode { get; set; }
        public Boolean SetMode(String Argument)
        {
            switch (Argument.ToLower())
            {
                case "normal":
                    CurrentMode = 1;
                    return false;
                case "super":
                    CurrentMode = 2;
                    return false;
                default:
                    return true;
            }
        }
    }
}