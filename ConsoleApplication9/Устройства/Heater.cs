using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Heater : OnOff, IHeater
    {
        public Heater() { }
        public ITemperature HeaterTemp { get; set; }
        public Heater(Boolean state)
        {
            State = state;
            Temperature t = new Temperature(12, 40, 20);
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