using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    [Serializable]
    public class TV : OnOff, IModeDevice, IChannelDevice, IOnOff
    {
        public TV() { }
        public TV(Boolean state, TVMode Mode, Channel channel)
        {
            State = state;
            this.Mode = Mode;
            Channel = channel;
        }
        public IModeModule Mode { get; set; }
        public IChannelModule Channel { get; set; }

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