﻿using System;

namespace ConsoleApplication9
{
    [Serializable]
    public class Conditioner : Device, IDevice, ITempDevice
    {
        public ITempModule Temp { get; set; }

        public Conditioner(bool state, Temp temp) : base(state)
        {
            Temp = temp;
        }

        public override void Info(string name)
        {
            Console.Write("Conditioner " + name);
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
        public void Set(int Argument)
        {
            Temp.Set(Argument);
        }
    }
}