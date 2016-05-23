using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Conditioner : OnOff, IConditioner, IOnOff
    {
        public Conditioner() { }
        public ITemperature ConditionerTemp { get; set; }
        public Conditioner(Boolean state, Temperature Temp)
        {
            State = state;
            ConditionerTemp = Temp;
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