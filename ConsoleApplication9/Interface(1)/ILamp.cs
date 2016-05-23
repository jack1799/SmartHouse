using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface ILight1 : IParam
    {
        ILight light { get; set; }
    }
}