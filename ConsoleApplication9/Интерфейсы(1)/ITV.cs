using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface ITV : IOnOff, IParam, IModes
    {
        IChannel Channel { get; set; }
    }
}