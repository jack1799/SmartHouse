using System;

namespace ConsoleApplication9
{
    [Serializable]
    public class Channel : IChannelModule
    {
        public int CurrentChannel { get; set; }
        public int MaxChannel { get; set; }
        public int MinChannel { get; set; }

        public Channel(int minChannel, int maxChannel, int currentChannel)
        {
            MinChannel = minChannel;
            MaxChannel = maxChannel;
            CurrentChannel = currentChannel;
        }

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

        public void SetChannel(int argument)
        {
            if ((argument >= MinChannel) & (argument <= MaxChannel))
            {
                CurrentChannel = argument;
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