using System;

namespace ConsoleApplication9
{
    [Serializable]
    public class Heater : Device, IDevice, ITempDevice
    {
        public ITempModule Temp { get; set; }

        public Heater(bool state, Temp temp) : base(state)
        {
            Temp = temp;
        }

        public override void Info(string name)
        {
            Console.Write("Heater " + name);
            if (state)
            {
                Console.Write(" on; ");
            }
            else
            {
                Console.Write(" off; ");
            }
            Console.WriteLine("temp " + Temp.CurrentTemp);
        }
        public void Plus()
        {
            Temp.Plus();
        }
        public void Minus()
        {
            Temp.Minus();
        }
        public void Set(int argument)
        {
            Temp.Set(argument);
        }
    }
}