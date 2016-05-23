using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Blender : OnOff, IModes, IOnOff
    {
        public Blender() { }
        public Blender(Boolean state, int mode, BlenderM m)
        {
            State = state;
            Mode = m;
            Mode.CurrentMode = mode;
        }
        public IMode Mode { get; set; }

        public Boolean SetMode(string Argument)
        {
            return Mode.SetMode(Argument);
        }
    }
}