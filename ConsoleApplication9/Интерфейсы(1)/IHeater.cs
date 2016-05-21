using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface IHeater : IOnOff, IParam
    {
        ITemperature HeaterTemp { get; set; }
    }
}