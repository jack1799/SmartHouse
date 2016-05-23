using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Blender : OnOff, IModes, IOnOff
    {
        public Blender() { }
        public Blender(bool state, int mode, BlenderM Mode)
        {
            State = state;
            BlenderMode = Mode;
            BlenderMode.CurrentMode = mode;
        }
        public IMode BlenderMode { get; set; }

        public Boolean SetMode(string Argument)
        {
            return BlenderMode.SetMode(Argument);
        }
    }
}