using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class Factory
    {
        public virtual Lamp CreateLamp(bool State,int MinLight, int MaxLight, int CurrentLight)
        {
            return new Lamp(State, new Light(MinLight, MaxLight, CurrentLight));
        }

        public virtual Fridge CreateFridge(bool State, int MinTemp, int MaxTemp, int CurrentTemp)
        {
            return new Fridge(State, new Temp(MinTemp, MaxTemp, CurrentTemp));
        }

        public virtual Heater CreateHeater(bool State, int MinTemp, int MaxTemp, int CurrentTemp)
        {
            return new Heater(State, new Temp(MinTemp, MaxTemp, CurrentTemp));
        }

        public virtual Conditioner CreateConditioner(bool State, int MinTemp, int MaxTemp, int CurrentTemp)
        {
            return new Conditioner(State, new Temp(MinTemp, MaxTemp, CurrentTemp));
        }

        public virtual Blender CreateBlender(bool State, int Mode)
        {
            return new Blender(State, new BlenderMode(Mode));
        }

        public virtual TV CreateTV(bool State, int Mode, int MinChannel, int MaxChannel, int CurrentChannel)
        {
            return new TV(State, new TVMode(Mode), new Channel(MinChannel, MaxChannel, CurrentChannel));
        }
    }
}