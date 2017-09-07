using System;

namespace ConsoleApplication9
{
    [Serializable]
    public class Lamp : Device, ILightDevice, IDevice
    {
        public ILightModule Light { get; set; }

        public Lamp(bool state, Light light) : base(state)
        {
            Light = light;
        }

        public override void Info(string name)
        {
            Console.Write("Lamp " + name);
            if (state)
            {
                Console.Write(" on; ");
            }
            else
            {
                Console.Write(" off; ");
            }
            Console.WriteLine("bright " + Light.CurrentLight);
        }
        public void Plus()
        {
            Light.Plus();
        }
        public void Minus()
        {
            Light.Minus();
        }
        public void Set(int argument)
        {
            Light.Set(argument);
        }
    }
}