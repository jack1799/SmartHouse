using System;

namespace ConsoleApplication9
{
    [Serializable]
    public abstract class Device : IDevice
    {
        protected bool state;

        public Device(bool state)
        {
            this.state = state;
        }

        public void On()
        {
            state = true;
        }
        public void Off()
        {
            state = false;
        }
        public virtual void Info(string name)
        {
            Console.Write("Blender " + name);
            if (state)
            {
                Console.WriteLine(" on; ");
            }
            else
            {
                Console.WriteLine(" off; ");
            }
        }
    }
}