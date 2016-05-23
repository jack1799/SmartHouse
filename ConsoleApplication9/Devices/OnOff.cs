using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface IOnOff
    {
        Boolean State { get; set; }

        void On();
        void Off();
    }

    public abstract class OnOff : IOnOff
    {
        public bool State { get; set; }

        public void On()
        {
            State = true;
        }
        public void Off()
        {
            State = false;
        }
    }
}