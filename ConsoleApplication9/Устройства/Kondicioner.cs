using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Conditioner : OnOff, IConditioner
    {
        public Conditioner() { }
        public ITemperature ConditionerTemp { get; set; }
        public Conditioner(Boolean state)
        {
            State = state;
            Temperature t = new Temperature(12, 40, 20);
            ConditionerTemp = t;
        }
        public void Plus()
        {
            ConditionerTemp.PlusTemp();
        }
        public void Minus()
        {
            ConditionerTemp.MinusTemp();
        }
        public void Set(int Argument)
        {
            ConditionerTemp.SetTemp(Argument);
        }
    }
}