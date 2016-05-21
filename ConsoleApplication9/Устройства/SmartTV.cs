using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class TV : OnOff, ITV
    {
        public TV() { }
        public TV(Boolean state, int mode, int channel)
        {
            State = state;
            TVM m = new TVM();
            Channel c = new Channel();
            Mode = m;
            Channel = c;
            Mode.CurrentMode = mode;

            Channel.CurrentChannel = channel;
        }
        public IMode Mode { get; set; }
        public IChannel Channel { get; set; }

        public void Set(int Argument)
        {
            Channel.SetChannel(Argument);
        }
        public void Minus()
        {
            Channel.PreviousChannel();
        }
        public void Plus()
        {
            Channel.NextChannel();
        }
        public Boolean SetMode(String Argument)
        {
            return Mode.SetMode(Argument);
        }
    }
}