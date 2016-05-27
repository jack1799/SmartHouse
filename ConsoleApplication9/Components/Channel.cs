using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    [Serializable]
    public class Channel : IChannelModule
    {
        public Channel() { }
        public Channel(int MinChannel, int MaxChannel, int CurrentChannel)
        {
            this.MinChannel = MinChannel;
            this.MaxChannel = MaxChannel;
            this.CurrentChannel = CurrentChannel;
        }
        public int CurrentChannel { get; set; }
        public int MaxChannel { get; set; }
        public int MinChannel { get; set; }

        public void NextChannel()
        {
            if ((CurrentChannel + 1) != MaxChannel)
            {
                CurrentChannel += 1;
            }
            else
            {
                Console.WriteLine("MinChannel=" + MinChannel + " MaxChannel=" + MaxChannel);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public void PreviousChannel()
        {
            if ((CurrentChannel - 1) != MinChannel)
            {
                CurrentChannel -= 1;
            }
            else
            {
                Console.WriteLine("MinChannel=" + MinChannel + " MaxChannel=" + MaxChannel);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public void SetChannel(int Argument)
        {
            if ((Argument >= MinChannel) & (Argument <= MaxChannel))
            {
                CurrentChannel = Argument;
            }
            else
            {
                Console.WriteLine("MinChannel=" + MinChannel + " MaxChannel=" + MaxChannel);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}