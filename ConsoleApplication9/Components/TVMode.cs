using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class TVMode : IMode
    {
        public TVMode() { }
        public TVMode(int mode)
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
                case "intensified":
                    CurrentMode = 2;
                    return false;
                case "super":
                    CurrentMode = 3;
                    return false;
                default:
                    return true;
            }
        }
    }
}