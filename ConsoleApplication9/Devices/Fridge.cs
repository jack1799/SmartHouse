using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    [Serializable]
    public class Fridge : OnOff, IOnOff, ITempDevice
    {
        public ITempModule Temp { get; set; }
        public Fridge() { }
        public Fridge(Boolean state, Temp Temp)
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