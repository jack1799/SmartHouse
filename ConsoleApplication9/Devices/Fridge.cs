using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Fridge : OnOff, IFridge, IOnOff
    {
        public ITemperature FridgeTemp { get; set; }
        public Fridge() { }
        public Fridge(Boolean state, Temperature Temp)
        {
            State = state;
            FridgeTemp = Temp;
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