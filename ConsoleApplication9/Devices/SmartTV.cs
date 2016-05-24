using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class TV : OnOff, IModes, IChannel1, IOnOff
    {
        public TV() { }
        public TV(Boolean state, int mode, int CurrentChannel, TVM Mode, Channel channel)
        {
            State = state;
            BlenderMode = Mode;
            Channel = channel;
            BlenderMode.CurrentMode = mode;
            Channel.CurrentChannel = CurrentChannel;
        }
        public IMode BlenderMode { get; set; }
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
            return BlenderMode.SetMode(Argument);
        }
    }
}