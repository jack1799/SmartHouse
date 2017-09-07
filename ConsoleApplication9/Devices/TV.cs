using System;

namespace ConsoleApplication9
{
    [Serializable]
    public class TV : Device, IModeDevice, IChannelDevice, IDevice
    {
        public IModeModule Mode { get; set; }
        public IChannelModule Channel { get; set; }

        public TV(bool state, TVMode mode, Channel channel) : base(state)
        {
            Mode = mode;
            Channel = channel;
        }

        public override void Info(string name)
        {
            Console.Write("TV " + name);
            if (state)
            {
                Console.Write(" on; ");
            }
            else
            {
                Console.Write(" off; ");
            }
            Console.Write((TVModes)Mode.CurrentMode);
            Console.Write(" mode; channel ");
            Console.WriteLine(Channel.CurrentChannel);
        }
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
        public bool SetMode(string Argument)
        {
            return Mode.SetMode(Argument);
        }
    }
}