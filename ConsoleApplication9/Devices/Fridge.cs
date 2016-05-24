﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Fridge : OnOff, IOnOff, IParam, ITemp, ISet
    {
        public ITemperature Temp { get; set; }
        public Fridge() { }
        public Fridge(Boolean state, Temperature Temp)
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