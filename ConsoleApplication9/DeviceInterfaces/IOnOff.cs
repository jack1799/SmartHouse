using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    public interface IOnOff
    {
        Boolean State { get; set; }

        void On();
        void Off();
    }
}
