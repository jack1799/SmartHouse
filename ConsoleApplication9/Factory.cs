using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Factory
    {
        public virtual Lamp CreateLamp()
        {
            return new Lamp(false, new Light(0, 100, 50));
        }

        public virtual Fridge CreateFridge()
        {
            return new Fridge(false, new Temperature(-12, -1, -4));
        }

        public virtual Heater CreateHeater()
        {
            return new Heater(false, new Temperature(12, 40, 20));
        }

        public virtual Conditioner CreateConditioner()
        {
            return new Conditioner(false, new Temperature(12, 40, 20));
        }

        public virtual Blender CreateBlender()
        {
            return new Blender(false, 1, new BlenderMode());
        }

        public virtual TV CreateTV()
        {
            return new TV(false, 1, 1, new TVMode(), new Channel());
        }
    }
}