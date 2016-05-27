using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface IModeModule
    {
        int CurrentMode { get; set; }

        Boolean SetMode(string Argument);
    }
}