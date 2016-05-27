using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    [Serializable]
    public class Heater : OnOff, IOnOff, ITemp1
    {
        public Heater() { }
        public ITemp Temp { get; set; }
        public Heater(Boolean state, Temp Temp)
        {
            State = state;
            this.Temp = Temp;
        }
        public void Plus()
        {
            Temp.PlusTemp();
        }
        public void Minus()
        {
            Temp.MinusTemp();
        }
        public void Set(int Argument)
        {
            Temp.SetTemp(Argument);
        }
    }
}