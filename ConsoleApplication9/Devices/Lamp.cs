using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    [Serializable]
    public class Lamp : OnOff, ILightDevice, IOnOff
    {
        public Lamp() { }
        public ILightModule Light { get; set; }
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