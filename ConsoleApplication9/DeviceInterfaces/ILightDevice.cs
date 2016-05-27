using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface ILightDevice : IParamDevice
    {
        ILightModule Light { get; set; }

    }
}