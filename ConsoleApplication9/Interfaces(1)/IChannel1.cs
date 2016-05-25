using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface IChannel1 : IParam
    {
        IChannel Channel { get; set; }
    }
}