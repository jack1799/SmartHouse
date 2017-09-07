using System;

namespace ConsoleApplication9
{
    [Serializable]
    public class Temp : ITempModule
    {
        public int CurrentTemp { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }

        public Temp(int min, int max, int currentTemp)
        {
            Min = min;
            Max = max;
            CurrentTemp = currentTemp;
        }

        public void Minus()
        {
            if ((CurrentTemp - 1) != Min)
            {
                CurrentTemp -= 1;
            }
            else
            {
                Console.WriteLine("MinTemp=" + Min + " MaxTemp=" + Max);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
        public void Plus()
        {
            if ((CurrentTemp + 1) != Max)
            {
                CurrentTemp += 1;
            }
            else
            {
                Console.WriteLine("MinTemp=" + Min + " MaxTemp=" + Max);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
        public void Set(int argument)
        {
            if ((argument >= Min) && (argument <= Max))
            {
                CurrentTemp = argument;
            }
            else
            {
                Console.WriteLine("MinTemp=" + Min + " MaxTemp=" + Max);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}