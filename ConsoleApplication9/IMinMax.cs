using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface IParam
    {
        int Max { get; }
        int Min { get; }

        void Minus();
        void Plus();
        void Set(int Argument);
    }
}