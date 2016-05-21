using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Lamp : OnOff, ILamp
    {
        public Lamp() { }
        public ILight light { get; set; }
        public Lamp(Boolean state)
        {
            State = state;
            Light l = new Light(0, 100, 50);
            light = l;
        }
        public void Plus()
        {
            light.PlusLight();
        }
        public void Minus()
        {
            light.MinusLight();
        }
        public void Set(int Argument)
        {
            light.SetLight(Argument);
        }
    }
}