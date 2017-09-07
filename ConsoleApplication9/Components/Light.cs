using System;

namespace ConsoleApplication9
{
    [Serializable]
    public class Light : ILightModule
    {
        public int CurrentLight { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }

        public Light(int min, int max, int currentLight)
        {
            Min = min;
            Max = max;
            CurrentLight = currentLight;
        }

        public void Minus()
        {
            --CurrentLight;
        }
        public void Plus()
        {
            ++CurrentLight;
        }
        public void Set(int argument)
        {
            if ((argument >= Min) && (argument <= Max))
            {
                CurrentLight = argument;
            }
            else
            {
                Console.WriteLine("MinLight=" + Min + " MaxLight=" + Max);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}