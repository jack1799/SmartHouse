using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Lamp : OnOff, ILight1, IOnOff
    {
        public Lamp() { }
        public ILight Light { get; set; }
        public Lamp(Boolean state, Light light)
        {
            State = state;
            Light = light;
        }
        public void Plus()
        {
            Light.PlusLight();
        }
        public void Minus()
        {
            Light.MinusLight();
        }
        public void Set(int Argument)
        {
            Light.SetLight(Argument);
        }
    }
}