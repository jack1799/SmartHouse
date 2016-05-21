using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Blender : OnOff, IBlender
    {
        public Blender() { }
        public Blender(Boolean state, int mode)
        {
            State = state;
            BlenderM m = new BlenderM();
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