using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplication9
{
    class Program
    {
        private static Factory factory = new Factory();
        private static Dictionary<string, Lamp> lampDictionary = new Dictionary<string, Lamp>();
        private static Dictionary<string, Fridge> fridgeDictionary = new Dictionary<string, Fridge>();
        private static Dictionary<string, Heater> heaterDictionary = new Dictionary<string, Heater>();
        private static Dictionary<string, Conditioner> conditionerDictionary = new Dictionary<string, Conditioner>();
        private static Dictionary<string, Blender> blenderDictionary = new Dictionary<string, Blender>();
        private static Dictionary<string, TV> tvDictionary = new Dictionary<string, TV>();

        private static void Main(string[] args)
        {
            OpenFile();

            while (true)
            {
                Console.Clear();
                OutputText();

                string[] commands = Console.ReadLine().Split(' ');

                if (commands[0].ToLower() == "exit" && commands.Length == 1)
                {
                    CreateFile();
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
                        LampCheckCommands(commands);
                        break;
                    case "fridge":
                        FridgeCheckCommands(commands);
                        break;
                    case "heater":
                        HeaterCheckCommands(commands);
                        break;
                    case "conditioner":
                        ConditionerCheckCommands(commands);
                        break;
                    case "blender":
                        BlenderCheckCommands(commands);
                        break;
                    case "tv":
                        TVCheckCommands(commands);
                        break;

                    default:
                        Help();
                        continue;
                }
            }
        }

        private static void OpenFile()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream("SmartHouse.dat", FileMode.Open))
                {
                    lampDictionary = (Dictionary<string, Lamp>)bf.Deserialize(fs);
                    fridgeDictionary = (Dictionary<string, Fridge>)bf.Deserialize(fs);
                    heaterDictionary = (Dictionary<string, Heater>)bf.Deserialize(fs);
                    conditionerDictionary = (Dictionary<string, Conditioner>)bf.Deserialize(fs);
                    blenderDictionary = (Dictionary<string, Blender>)bf.Deserialize(fs);
                    tvDictionary = (Dictionary<string, TV>)bf.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                lampDictionary.Add("1", factory.CreateLamp());
                fridgeDictionary.Add("2", factory.CreateFridge());
                heaterDictionary.Add("3", factory.CreateHeater());
                conditionerDictionary.Add("4", factory.CreateConditioner());
                blenderDictionary.Add("5", factory.CreateBlender());
                tvDictionary.Add("6", factory.CreateTV());
            }
        }
        private static void CreateFile()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("SmartHouse.dat", FileMode.Create))
            {
                bf.Serialize(fs, lampDictionary);
                bf.Serialize(fs, fridgeDictionary);
                bf.Serialize(fs, heaterDictionary);
                bf.Serialize(fs, conditionerDictionary);
                bf.Serialize(fs, blenderDictionary);
                bf.Serialize(fs, tvDictionary);
            }
        }

        private static void Help()
        {
            Console.WriteLine("DeviceName: Lamp, Fridge, Heater, Conditioner, Blender, TV");
            Console.WriteLine();
            Console.WriteLine("Commands:");
            Console.WriteLine();
            Console.WriteLine("\tadd [DeviceType] [DeviceName]");
            Console.WriteLine("\tdel [DeviceType] [DeviceName]");
            Console.WriteLine("\ton [DeviceType] [DeviceName]");
            Console.WriteLine("\toff [DeviceType] [DeviceName]");
            Console.WriteLine();
            Console.WriteLine("Param: bright, temp, channel");
            Console.WriteLine();
            Console.WriteLine("\tParam+ [DeviceType] [DeviceName]");
            Console.WriteLine("\tParam- [DeviceType] [DeviceName]");
            Console.WriteLine();
            Console.WriteLine("Mode [DeviceType] [DeviceName]");
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
        private static void OutputText()
        {
            foreach (KeyValuePair<string, Lamp> lamp in lampDictionary)
            {
                lamp.Value.Info(lamp.Key);
            }
            foreach (KeyValuePair<string, Fridge> fridge in fridgeDictionary)
            {
                fridge.Value.Info(fridge.Key);
            }
            foreach (KeyValuePair<string, Heater> heater in heaterDictionary)
            {
                heater.Value.Info(heater.Key);
            }
            foreach (KeyValuePair<string, Conditioner> conditioner in conditionerDictionary)
            {
                conditioner.Value.Info(conditioner.Key);
            }
            foreach (KeyValuePair<string, Blender> blender in blenderDictionary)
            {
                blender.Value.Info(blender.Key);
            }
            foreach (KeyValuePair<string, TV> tv in tvDictionary)
            {
                tv.Value.Info(tv.Key);
            }
        }
        private static void DeviceExist()
        {
            Console.WriteLine("The device with the same name already exists.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private static void LampCheckCommands(string[] commands)
        {
            if (commands[0].ToLower() == "add")
            {
                if (!lampDictionary.ContainsKey(commands[2]))
                {
                    lampDictionary.Add(commands[2], factory.CreateLamp());
                }
                else
                {
                    DeviceExist();
                }
                return;
            }

            if (!lampDictionary.ContainsKey(commands[2]))
            {
                Help();
                return;
            }

            switch (commands[0].ToLower())
            {
                case "del":
                    lampDictionary.Remove(commands[2]);
                    break;
                case "on":
                    lampDictionary[commands[2]].On();
                    break;
                case "off":
                    lampDictionary[commands[2]].Off();
                    break;
                case "bright+":
                    lampDictionary[commands[2]].Plus();
                    break;
                case "bright-":
                    lampDictionary[commands[2]].Minus();
                    break;
                default:
                    try
                    {
                        lampDictionary[commands[2]].Set(Int32.Parse(commands[0]));
                    }
                    catch (FormatException)
                    {
                        Help();
                    }
                    break;
            }
        }
        private static void FridgeCheckCommands(string[] commands)
        {
            if (commands[0].ToLower() == "add")
            {
                if (!fridgeDictionary.ContainsKey(commands[2]))
                {
                    fridgeDictionary.Add(commands[2], factory.CreateFridge(false, -12, -1, -4));
                }
                else
                {
                    DeviceExist();
                }
                return;
            }

            if (!fridgeDictionary.ContainsKey(commands[2]))
            {
                Help();
                return;
            }

            switch (commands[0].ToLower())
            {
                case "del":
                    fridgeDictionary.Remove(commands[2]);
                    break;
                case "on":
                    fridgeDictionary[commands[2]].On();
                    break;
                case "off":
                    fridgeDictionary[commands[2]].Off();
                    break;
                case "temp+":
                    fridgeDictionary[commands[2]].Plus();
                    break;
                case "temp-":
                    fridgeDictionary[commands[2]].Minus();
                    break;
                default:
                    try
                    {
                        fridgeDictionary[commands[2]].Set(Int32.Parse(commands[0]));
                    }
                    catch (FormatException)
                    {
                        Help();
                    }
                    break;
            }
        }
        private static void HeaterCheckCommands(string[] commands)
        {
            if (commands[0].ToLower() == "add")
            {
                if (!heaterDictionary.ContainsKey(commands[2]))
                {
                    heaterDictionary.Add(commands[2], factory.CreateHeater(false, 12, 40, 20));
                }
                else
                {
                    DeviceExist();
                }

                return;
            }

            if (!heaterDictionary.ContainsKey(commands[2]))
            {
                Help();
                return;
            }

            switch (commands[0].ToLower())
            {
                case "del":
                    heaterDictionary.Remove(commands[2]);
                    break;
                case "on":
                    heaterDictionary[commands[2]].On();
                    break;
                case "off":
                    heaterDictionary[commands[2]].Off();
                    break;
                case "temp+":
                    heaterDictionary[commands[2]].Plus();
                    break;
                case "temp-":
                    heaterDictionary[commands[2]].Minus();
                    break;
                default:
                    try
                    {
                        heaterDictionary[commands[2]].Set(Int32.Parse(commands[0]));
                    }
                    catch (FormatException)
                    {
                        Help();
                    }
                    break;
            }
        }
        private static void ConditionerCheckCommands(string[] commands)
        {
            if (commands[0].ToLower() == "add")
            {
                if (!conditionerDictionary.ContainsKey(commands[2]))
                {
                    conditionerDictionary.Add(commands[2], factory.CreateConditioner(false, 12, 40, 20));
                }
                else
                {
                    DeviceExist();
                }
                return;
            }

            if (!conditionerDictionary.ContainsKey(commands[2]))
            {
                Help();
                return;
            }

            switch (commands[0].ToLower())
            {
                case "del":
                    conditionerDictionary.Remove(commands[2]);
                    break;
                case "on":
                    conditionerDictionary[commands[2]].On();
                    break;
                case "off":
                    conditionerDictionary[commands[2]].Off();
                    break;
                case "temp+":
                    conditionerDictionary[commands[2]].Plus();
                    break;
                case "temp-":
                    conditionerDictionary[commands[2]].Minus();
                    break;
                default:
                    try
                    {
                        conditionerDictionary[commands[2]].Set(Int32.Parse(commands[0]));
                    }
                    catch (FormatException)
                    {
                        Help();
                    }
                    break;
            }
        }
        private static void BlenderCheckCommands(string[] commands)
        {
            if (commands[0].ToLower() == "add")
            {
                if (!blenderDictionary.ContainsKey(commands[2]))
                {
                    blenderDictionary.Add(commands[2], factory.CreateBlender(false, BlenderModes.Normal));
                }
                else
                {
                    DeviceExist();
                }
                return;
            }

            if (!blenderDictionary.ContainsKey(commands[2]))
            {
                Help();
                return;
            }

            switch (commands[0].ToLower())
            {
                case "del":
                    blenderDictionary.Remove(commands[2]);
                    break;
                case "on":
                    blenderDictionary[commands[2]].On();
                    break;
                case "off":
                    blenderDictionary[commands[2]].Off();
                    break;
                default:
                    if (blenderDictionary[commands[2]].SetMode(commands[0])) break;
                    Help();
                    break;
            }
        }
        private static void TVCheckCommands(string[] commands)
        {
            if (commands[0].ToLower() == "add")
            {
                if (!tvDictionary.ContainsKey(commands[2]))
                {
                    tvDictionary.Add(commands[2], factory.CreateTV(false, TVModes.Normal, 0, 100, 1));
                }
                else
                {
                    DeviceExist();
                }
                return;
            }

            if (!tvDictionary.ContainsKey(commands[2]))
            {
                Help();
                return;
            }

            switch (commands[0].ToLower())
            {
                case "del":
                    tvDictionary.Remove(commands[2]);
                    break;
                case "on":
                    tvDictionary[commands[2]].On();
                    break;
                case "off":
                    tvDictionary[commands[2]].Off();
                    break;
                case "channel+":
                    tvDictionary[commands[2]].Plus();
                    break;
                case "channel-":
                    tvDictionary[commands[2]].Minus();
                    break;
                default:
                    if (tvDictionary[commands[2]].SetMode(commands[0])) break;
                    try
                    {
                        tvDictionary[commands[2]].Set(Int32.Parse(commands[0]));
                    }
                    catch (FormatException)
                    {
                        Help();
                    }
                    break;
            }
        }
    }
}