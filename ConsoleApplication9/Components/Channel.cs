using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Channel : IChannel
    {
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