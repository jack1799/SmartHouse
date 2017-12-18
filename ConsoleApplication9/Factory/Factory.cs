namespace ConsoleApplication9
{
    public class Factory
    {
        public virtual Lamp CreateLamp()
        {
            return CreateLamp(false, 0, 100, 50);
        }
        public virtual Lamp CreateLamp(bool State,int MinLight, int MaxLight, int CurrentLight)
        {
            return new Lamp(State, new Light(MinLight, MaxLight, CurrentLight));
        }

        public virtual Fridge CreateFridge()
        {
            return CreateFridge(false, -12, -1, -4);
        }
        public virtual Fridge CreateFridge(bool State, int MinTemp, int MaxTemp, int CurrentTemp)
        {
            return new Fridge(State, new Temp(MinTemp, MaxTemp, CurrentTemp));
        }

        public virtual Heater CreateHeater()
        {
            return CreateHeater(false, 12, 40, 20);
        }
        public virtual Heater CreateHeater(bool State, int MinTemp, int MaxTemp, int CurrentTemp)
        {
            return new Heater(State, new Temp(MinTemp, MaxTemp, CurrentTemp));
        }

        public virtual Conditioner CreateConditioner()
        {
            return CreateConditioner(false, 12, 40, 20);
        }
        public virtual Conditioner CreateConditioner(bool State, int MinTemp, int MaxTemp, int CurrentTemp)
        {
            return new Conditioner(State, new Temp(MinTemp, MaxTemp, CurrentTemp));
        }

        public virtual Blender CreateBlender()
        {
            return CreateBlender(false, BlenderModes.Normal);
        }
        public virtual Blender CreateBlender(bool State, BlenderModes Mode)
        {
            return new Blender(State, new BlenderMode(Mode));
        }

        public virtual TV CreateTV()
        {
            return CreateTV(false, TVModes.Normal, 0, 100, 1);
        }
        public virtual TV CreateTV(bool State, TVModes Mode, int MinChannel, int MaxChannel, int CurrentChannel)
        {
            return new TV(State, new TVMode(Mode), new Channel(MinChannel, MaxChannel, CurrentChannel));
        }
    }
}