using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Heater : OnOff, IHeater, IOnOff
    {
        public Heater() { }
        public ITemperature HeaterTemp { get; set; }
        public Heater(Boolean state, Temperature t)
        {
            State = state;
            HeaterTemp = t;
        }
        public void Plus()
        {
            HeaterTemp.PlusTemp();
        }
        public void Minus()
        {
            HeaterTemp.MinusTemp();
        }
        public void Set(int Argument)
        {
            HeaterTemp.SetTemp(Argument);
        }
    }
}