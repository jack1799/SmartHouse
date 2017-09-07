using System;

namespace ConsoleApplication9
{
    [Serializable]
    public class Blender : Device, IModeDevice, IDevice
    {
        public IModeModule Mode { get; set; }

        public Blender(bool state, BlenderMode mode) : base(state)
        {
            Mode = mode;
        }

        public override void Info(string name)
        {
            Console.Write("Blender " + name);
            if (state)
            {
                Console.Write(" on; ");
            }
            else
            {
                Console.Write(" off; ");
            }
            Console.Write((BlenderModes)Mode.CurrentMode);
            Console.WriteLine(" mode");
        }
        public bool SetMode(string Argument)
        {
            return Mode.SetMode(Argument);
        }
    }
}