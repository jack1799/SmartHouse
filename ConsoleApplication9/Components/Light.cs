using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    [Serializable]
    public class Light : ILight
    {
        public Light(int MinLight, int MaxLight, int CurrentLight)
        {
            this.MaxLight = MaxLight;
            this.MinLight = MinLight;
            this.CurrentLight = CurrentLight;
        }
        public Light() { }
        public int CurrentLight { get; set; }
        public int MaxLight { get; set; }
        public int MinLight { get; set; }

        public void MinusLight()
        {
            --CurrentLight;
        }

        public void PlusLight()
        {
            ++CurrentLight;
        }

        public void SetLight(int Argument)
        {
            if ((Argument >= MinLight) & (Argument <= MaxLight))
            {
                CurrentLight = Argument;
            }
            else
            {
                Console.WriteLine("MinLight="+MinLight+" MaxLight="+MaxLight);

            }
        }
    }
}