using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface IChannel
    {
        int CurrentChannel { get; set; }
        int MaxChannel { get; set; }
        int MinChannel { get; set; }

        void NextChannel();
        void PreviousChannel();
        void SetChannel(int Argument);
    }
}