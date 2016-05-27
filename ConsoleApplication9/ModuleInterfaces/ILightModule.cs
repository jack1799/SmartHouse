using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface ILightModule : IParamModule
    {
        int CurrentLight { get; set; }
    }
}