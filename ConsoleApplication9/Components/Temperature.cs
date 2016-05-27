using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    [Serializable]
    public class Temp : ITemp
    {
        public Temp(int MinTemp,int MaxTemp,int CurrentTemp)
        {
            this.MinTemp = MinTemp;
            this.MaxTemp = MaxTemp;
            this.CurrentTemp = CurrentTemp;
        }
        public int CurrentTemp { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }

        public void MinusTemp()
        {
            if ((CurrentTemp -1) != MinTemp)
            {
                CurrentTemp -= 1;
            }
            else
            {
                Console.WriteLine("MinTemp=" + MinTemp + " MaxTemp=" + MaxTemp);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public void PlusTemp()
        {
            if ((CurrentTemp + 1) != MaxTemp)
            {
                CurrentTemp += 1;
            }
            else
            {
                Console.WriteLine("MinTemp=" + MinTemp + " MaxTemp=" + MaxTemp);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public void SetTemp(int Argument)
        {
            if ((Argument >= MinTemp) & (Argument <= MaxTemp))
            {
                CurrentTemp = Argument;
            }
            else
            {
                Console.WriteLine("MinTemp=" + MinTemp + " MaxTemp=" + MaxTemp);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}