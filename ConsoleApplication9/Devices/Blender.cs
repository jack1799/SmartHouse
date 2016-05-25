using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    [Serializable]
    public class Blender : OnOff, IModes, IOnOff
    {
        public Blender() { }
        public Blender(bool state, BlenderMode Mode)
        {
            State = state;
            this.Mode = Mode;
        }
        public IMode Mode { get; set; }

        public Boolean SetMode(string Argument)
        {
            return Mode.SetMode(Argument);
        }
    }
}