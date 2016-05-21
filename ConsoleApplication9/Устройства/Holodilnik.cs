using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Fridge : OnOff, IFridge
    {
        public ITemperature FridgeTemp { get; set; }
        public Fridge() { }
        public Fridge(Boolean state)
        {
            State = state;
            Temperature t = new Temperature(-12, -1, -4);
            FridgeTemp = t;
        }
        public void Plus()
        {
            FridgeTemp.PlusTemp();
        }
        public void Minus()
        {
            FridgeTemp.MinusTemp();
        }
        public void Set(int Argument)
        {
            FridgeTemp.SetTemp(Argument);
        }
    }
}