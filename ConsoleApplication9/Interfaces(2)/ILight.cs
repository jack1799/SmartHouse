using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface ILight
    {
        int CurrentLight { get; set; }
        int MaxLight { get; }
        int MinLight { get; }

        void MinusLight();
        void PlusLight();
        void SetLight(int Argument);
    }
}