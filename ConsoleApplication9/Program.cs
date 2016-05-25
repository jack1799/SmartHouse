using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    class Program
    {
        private static void Help()
        {
            Console.WriteLine("DeviceName: Lamp, Fridge, Heater, Conditioner, Blender, TV");
            Console.WriteLine();
            Console.WriteLine("Commands:");
            Console.WriteLine();
            Console.WriteLine("\tadd [DeviceName] [Name]");
            Console.WriteLine("\tdel [DeviceName] [Name]");
            Console.WriteLine("\ton [DeviceName] [Name]");
            Console.WriteLine("\toff [DeviceName] [Name]");
            Console.WriteLine();
            Console.WriteLine("Param: bright, temp, channel");
            Console.WriteLine();
            Console.WriteLine("\tParam+ [DeviceName] [Name]");
            Console.WriteLine("\tParam- [DeviceName] [Name]");
            Console.WriteLine();
            Console.WriteLine("Mode [DeviceName] [Name]");
            Console.WriteLine();
            Console.WriteLine("Modes for Blender");
            Console.WriteLine();
            Console.WriteLine("\tNormal");
            Console.WriteLine("\tSuper");
            Console.WriteLine();
            Console.WriteLine("Modes for TV");
            Console.WriteLine();
            Console.WriteLine("\tNormal");
            Console.WriteLine("\tIntensified");
            Console.WriteLine("\tSuper");
            Console.WriteLine();
            Console.WriteLine("Exit");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Factory factory = new Factory();

            IDictionary<string, Lamp> LampDictionary = new Dictionary<string, Lamp>();
            IDictionary<string, Fridge> FridgeDictionary = new Dictionary<string, Fridge>();
            IDictionary<string, Heater> HeaterDictionary = new Dictionary<string, Heater>();
            IDictionary<string, Conditioner> ConditionerDictionary = new Dictionary<string, Conditioner>();
            IDictionary<string, Blender> BlenderDictionary = new Dictionary<string, Blender>();
            IDictionary<string, TV> TVDictionary = new Dictionary<string, TV>();
            try
            { 
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("SmartHouse.dat", FileMode.Open))
            {
                Dictionary<string, Lamp> LDictionary = (Dictionary<string, Lamp>)bf.Deserialize(fs);
                Dictionary<string, Fridge> FDictionary = (Dictionary<string, Fridge>)bf.Deserialize(fs);
                Dictionary<string, Heater> HDictionary = (Dictionary<string, Heater>)bf.Deserialize(fs);
                Dictionary<string, Conditioner> CDictionary = (Dictionary<string, Conditioner>)bf.Deserialize(fs);
                Dictionary<string, Blender> BDictionary = (Dictionary<string, Blender>)bf.Deserialize(fs);
                Dictionary<string, TV> TDictionary = (Dictionary<string, TV>)bf.Deserialize(fs);

                foreach (var Lamp in LDictionary)
                {
                    LampDictionary.Add(Lamp.Key, factory.CreateLamp(Lamp.Value.State, Lamp.Value.Light.MinLight, Lamp.Value.Light.MaxLight, Lamp.Value.Light.CurrentLight));
                }

                foreach (var Fridge in FDictionary)
                {
                        FridgeDictionary.Add(Fridge.Key, factory.CreateFridge(Fridge.Value.State, Fridge.Value.Temp.MinTemp, Fridge.Value.Temp.MaxTemp, Fridge.Value.Temp.CurrentTemp));
                }

                foreach (var Heater in HDictionary)
                {
                    HeaterDictionary.Add(Heater.Key, factory.CreateHeater(Heater.Value.State, Heater.Value.Temp.MinTemp, Heater.Value.Temp.MaxTemp, Heater.Value.Temp.CurrentTemp));
                }

                foreach (var Conditioner in CDictionary)
                {
                    ConditionerDictionary.Add(Conditioner.Key, factory.CreateConditioner(Conditioner.Value.State, Conditioner.Value.Temp.MinTemp, Conditioner.Value.Temp.MaxTemp, Conditioner.Value.Temp.CurrentTemp));
                }

                foreach (var Blender in BDictionary)
                {
                    BlenderDictionary.Add(Blender.Key, factory.CreateBlender(Blender.Value.State, Blender.Value.Mode.CurrentMode));
                }

                foreach (var TV in TDictionary)
                {
                    TVDictionary.Add(TV.Key, factory.CreateTV(TV.Value.State, TV.Value.Mode.CurrentMode, TV.Value.Channel.MinChannel, TV.Value.Channel.MaxChannel, TV.Value.Channel.CurrentChannel));
                }
            }
        }
        catch (Exception)
        {
                    LampDictionary.Add("1", factory.CreateLamp(false, 0, 100, 50));
                    FridgeDictionary.Add("2", factory.CreateFridge(false, -12, -1, -4));
                    HeaterDictionary.Add("3", factory.CreateHeater(false, 12, 40, 20));
                    ConditionerDictionary.Add("4", factory.CreateConditioner(false, 12, 40, 20));
                    BlenderDictionary.Add("5", factory.CreateBlender(false, 1));
                    TVDictionary.Add("6", factory.CreateTV(false, 1, 0, 100, 1));
        }
            while (true)
            {
                Console.Clear();
                foreach (var Lamp in LampDictionary)
                {
                    Console.Write("Lamp " + Lamp.Key );
                    if (Lamp.Value.State)
                    {
                        Console.Write(" on; ");
                    }
                    else
                    {
                        Console.Write(" off; ");
                    }
                    Console.WriteLine("bright " + Lamp.Value.Light.CurrentLight);
                }
                foreach (var Fridge in FridgeDictionary)
                {
                    Console.Write("Fridge " + Fridge.Key);
                    if (Fridge.Value.State)
                    {
                        Console.Write(" on; ");
                    }
                    else
                    {
                        Console.Write(" off; ");
                    }
                    Console.WriteLine("temp " + Fridge.Value.Temp.CurrentTemp);
                }

                foreach (var Heater in HeaterDictionary)
                {
                    Console.Write("Heater " + Heater.Key);
                    if (Heater.Value.State)
                    {
                        Console.Write(" on; ");
                    }
                    else
                    {
                        Console.Write(" off; ");
                    }
                    Console.WriteLine("temp " + Heater.Value.Temp.CurrentTemp);
                }

                foreach (var Conditioner in ConditionerDictionary)
                {
                    Console.Write("Conditioner " + Conditioner.Key);
                    if (Conditioner.Value.State)
                    {
                        Console.Write(" on; ");
                    }
                    else
                    {
                        Console.Write(" off; ");
                    }
                    Console.WriteLine("temp " + Conditioner.Value.Temp.CurrentTemp);
                }

                foreach (var Blender in BlenderDictionary)
                {
                    Console.Write("Blender " + Blender.Key);
                    if (Blender.Value.State)
                    {
                        Console.Write(" on; ");
                    }
                    else
                    {
                        Console.Write(" off; ");
                    }
                    Console.Write((BlenderModes)Blender.Value.Mode.CurrentMode);
                    Console.WriteLine(" mode");
                }

                foreach (var TV in TVDictionary)
                {
                    Console.Write("TV " + TV.Key);
                    if (TV.Value.State)
                    {
                        Console.Write(" on; ");
                    }
                    else
                    {
                        Console.Write(" off; ");
                    }
                    Console.Write((TVModes)TV.Value.Mode.CurrentMode);
                    Console.Write(" mode; channel ");
                    Console.WriteLine(TV.Value.Channel.CurrentChannel);
                }

                string[] commands = Console.ReadLine().Split(' ');
                if (commands[0].ToLower() == "exit" & commands.Length == 1)
                {
                    using (FileStream fs = new FileStream("SmartHouse.dat", FileMode.OpenOrCreate))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, LampDictionary);
                        bf.Serialize(fs, FridgeDictionary);
                        bf.Serialize(fs, HeaterDictionary);
                        bf.Serialize(fs, ConditionerDictionary);
                        bf.Serialize(fs, BlenderDictionary);
                        bf.Serialize(fs, TVDictionary);
                    }
                    return;
                }
                if (commands.Length != 3)
                {
                    Help();
                    continue;
                }
                switch (commands[1].ToLower())
                {
                    case "lamp":
                        if (commands[0].ToLower() == "add" && !LampDictionary.ContainsKey(commands[2]))
                        {
                            LampDictionary.Add(commands[2],factory.CreateLamp(false, 0, 100, 50));
                            continue;
                        }
                        if (commands[0].ToLower() == "add" && LampDictionary.ContainsKey(commands[2]))
                        {
                            Console.WriteLine("The device with the same name already exists");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            continue;
                        }
                        if (!LampDictionary.ContainsKey(commands[2]))
                        {
                            Help();
                            continue;
                        }
                        switch (commands[0].ToLower())
                        {
                            case "del":
                                LampDictionary.Remove(commands[2]);
                                break;
                            case "on":
                                LampDictionary[commands[2]].On();
                                break;
                            case "off":
                                LampDictionary[commands[2]].Off();
                                break;
                            case "bright+":
                                LampDictionary[commands[2]].Plus();
                                break;
                            case "bright-":
                                LampDictionary[commands[2]].Minus();
                                break;
                            default:
                                try
                                {
                                    LampDictionary[commands[2]].Set(Int32.Parse(commands[0]));
                                }
                                catch (FormatException)
                                {
                                    Help();  
                                }
                                break;
                        }
                        break;

                    case "fridge":
                        if (commands[0].ToLower() == "add" && !FridgeDictionary.ContainsKey(commands[2]))
                        {
                            FridgeDictionary.Add(commands[2],factory.CreateFridge(false, -12, -1, -4));
                            continue;
                        }
                        if (commands[0].ToLower() == "add" && FridgeDictionary.ContainsKey(commands[2]))
                        {
                            Console.WriteLine("The device with the same name already exists");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            continue;
                        }
                        if (!FridgeDictionary.ContainsKey(commands[2]))
                        {
                            Help();
                            continue;
                        }
                        switch (commands[0].ToLower())
                        {
                            case "del":
                                FridgeDictionary.Remove(commands[2]);
                                break;
                            case "on":
                                FridgeDictionary[commands[2]].On();
                                break;
                            case "off":
                                FridgeDictionary[commands[2]].Off();
                                break;
                            case "temp+":
                                FridgeDictionary[commands[2]].Plus();
                                break;
                            case "temp-":
                                FridgeDictionary[commands[2]].Minus();
                                break;
                            default:
                                try
                                {
                                    FridgeDictionary[commands[2]].Set(Int32.Parse(commands[0]));
                                }
                                catch (FormatException)
                                {
                                    Help();
                                }
                                break;
                        }
                        break;

                    case "heater":
                        if (commands[0].ToLower() == "add" && !HeaterDictionary.ContainsKey(commands[2]))
                        {
                            HeaterDictionary.Add(commands[2], factory.CreateHeater(false, 12, 40, 20));
                            continue;
                        }
                        if (commands[0].ToLower() == "add" && HeaterDictionary.ContainsKey(commands[2]))
                        {
                            Console.WriteLine("The device with the same name already exists");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            continue;
                        }
                        if (!HeaterDictionary.ContainsKey(commands[2]))
                        {
                            Help();
                            continue;
                        }
                        switch (commands[0].ToLower())
                        {
                            case "del":
                                HeaterDictionary.Remove(commands[2]);
                                break;
                            case "on":
                                HeaterDictionary[commands[2]].On();
                                break;
                            case "off":
                                HeaterDictionary[commands[2]].Off();
                                break;
                            case "temp+":
                                HeaterDictionary[commands[2]].Plus();
                                break;
                            case "temp-":
                                HeaterDictionary[commands[2]].Minus();
                                break;
                            default:
                                try
                                {
                                    HeaterDictionary[commands[2]].Set(Int32.Parse(commands[0]));
                                }
                                catch (FormatException)
                                {
                                    Help();
                                }
                                break;
                        }
                        break;

                    case "conditioner":
                        if (commands[0].ToLower() == "add" && !ConditionerDictionary.ContainsKey(commands[2]))
                        {
                            ConditionerDictionary.Add(commands[2], factory.CreateConditioner(false, 12, 40, 20));
                            continue;
                        }
                        if (commands[0].ToLower() == "add" && ConditionerDictionary.ContainsKey(commands[2]))
                        {
                            Console.WriteLine("The device with the same name already exists");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            continue;
                        }
                        if (!ConditionerDictionary.ContainsKey(commands[2]))
                        {
                            Help();
                            continue;
                        }
                        switch (commands[0].ToLower())
                        {
                            case "del":
                                ConditionerDictionary.Remove(commands[2]);
                                break;
                            case "on":
                                ConditionerDictionary[commands[2]].On();
                                break;
                            case "off":
                                ConditionerDictionary[commands[2]].Off();
                                break;
                            case "temp+":
                                ConditionerDictionary[commands[2]].Plus();
                                break;
                            case "temp-":
                                ConditionerDictionary[commands[2]].Minus();
                                break;
                            default:
                                try
                                {
                                    ConditionerDictionary[commands[2]].Set(Int32.Parse(commands[0]));
                                }
                                catch (FormatException)
                                {
                                    Help();
                                }
                                break;
                        }
                        break;

                    case "blender":
                        if (commands[0].ToLower() == "add" && !BlenderDictionary.ContainsKey(commands[2]))
                        {
                            BlenderDictionary.Add(commands[2], factory.CreateBlender(false, 1));
                            continue;
                        }
                        if (commands[0].ToLower() == "add" && BlenderDictionary.ContainsKey(commands[2]))
                        {
                            Console.WriteLine("The device with the same name already exists");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            continue;
                        }
                        if (!BlenderDictionary.ContainsKey(commands[2]))
                        {
                            Help();
                            continue;
                        }
                        switch (commands[0].ToLower())
                        {
                            case "del":
                                BlenderDictionary.Remove(commands[2]);
                                break;
                            case "on":
                                BlenderDictionary[commands[2]].On();
                                break;
                            case "off":
                                BlenderDictionary[commands[2]].Off();
                                break;
                            default:
                                if (BlenderDictionary[commands[2]].SetMode(commands[0]))
                                {
                                    Help();
                                }
                                break;
                        }
                        break;

                    case "tv":
                        if (commands[0].ToLower() == "add" && !TVDictionary.ContainsKey(commands[2]))
                        {
                            TVDictionary.Add(commands[2],factory.CreateTV(false, 1, 0, 100, 1));
                            continue;
                        }
                        if (commands[0].ToLower() == "add" && TVDictionary.ContainsKey(commands[2]))
                        {
                            Console.WriteLine("The device with the same name already exists");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            continue;
                        }
                        if (!TVDictionary.ContainsKey(commands[2]))
                        {
                            Help();
                            continue;
                        }
                        switch (commands[0].ToLower())
                        {
                            case "del":
                                TVDictionary.Remove(commands[2]);
                                break;
                            case "on":
                                TVDictionary[commands[2]].On();
                                break;
                            case "off":
                                TVDictionary[commands[2]].Off();
                                break;
                            case "channel+":
                                TVDictionary[commands[2]].Plus();
                                break;
                            case "channel-":
                                TVDictionary[commands[2]].Minus();
                                break;
                            default:
                                if (TVDictionary[commands[2]].SetMode(commands[0]))
                                {
                                    try
                                    {
                                            TVDictionary[commands[2]].Set(Int32.Parse(commands[0]));
                                    }
                                    catch (FormatException)
                                    {
                                        Help();
                                    }
                                }
                                break;
                        }
                        break;

                    default:
                        Help();
                        continue;
                }
            }
        }
    }
}