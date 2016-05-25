using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface ITemperature
    {
        int CurrentTemp { get; set; }
        int MaxTemp { get; set; }
        int MinTemp { get; set; }

        void MinusTemp();
        void PlusTemp();
        void SetTemp(int Argument);
    }
}