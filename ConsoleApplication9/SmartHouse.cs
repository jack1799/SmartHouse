using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplication9
{
    public static class SmartHouse
    {
        public static List<IDevice> deviceList = new List<IDevice>();
        public static List<Device> deviceTypes = new List<Device>();

        public static void Start()
        {
            OpenFile();

            while (true)
            {
                Console.Clear();

                OutputText();

                string[] commands = Console.ReadLine().Split(' ');

                if (Check(commands)) return;
            }
        }

        private static void OpenFile()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream("SmartHouse.dat", FileMode.Open))
                {
                    deviceList = (List<IDevice>)bf.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                foreach (Device type in deviceTypes)
                {
                    deviceList.Add(type.CreateDefault());
                }
            }
        }
        private static void CreateFile()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("SmartHouse.dat", FileMode.Create))
            {
                bf.Serialize(fs, deviceList);
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
        private static void DeviceExist()
        {
            Console.WriteLine("The device with the same name already exists.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        private static void OutputText()
        {
            foreach (IDevice device in deviceList)
            {
                device.Info();
            }
        }

        private static bool Check(string[] commands)
        {
            if (commands[0].ToLower() == "exit" && commands.Length == 1)
            {
                CreateFile();
                return true;
            }

            if (commands.Length != 3)
            {
                Help();
                return false;
            }

            if (commands[0].ToLower() == "add")
            {
                if (ContainsName(commands[2]))
                {
                    DeviceExist();
                    return false;
                }
                if (ContainsType(commands[1])) deviceList.Add(ReturnType(commands[1]).CreateDefault());
                return false;
            }

            if (ContainsName(commands[2]))
            {
                Help();
                return false;
            }

            switch (commands[0].ToLower())
            {
                case "del":
                    Remove(commands[2]);
                    break;
                case "on":
                    deviceList[ReturnDeviceNumber(commands[2])].On();
                    break;
                case "off":
                    deviceList[ReturnDeviceNumber(commands[2])].Off();
                    break;
            }

            ReturnType(commands[1]).Check(commands, ReturnDeviceNumber(commands[2]));

            return false;
        }

        private static bool ContainsType(string command)
        {
            foreach (Device type in deviceTypes)
            {
                if (command.ToLower() == type.ToString().ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        private static Device ReturnType(string command)
        {
            foreach (Device type in deviceTypes)
            {
                if (command.ToLower() == type.ToString().ToLower())
                {
                    return type;
                }
            }
            return null;
        }
        private static bool ContainsName(string command)
        {
            foreach (IDevice device in deviceList)
            {
                if (device.Name == command)
                {
                    return true;
                }
            }
            return false;
        }
        private static void Remove(string name)
        {
            deviceList.Remove(deviceList[ReturnDeviceNumber(name)]);
        }


        public static int ReturnDeviceNumber(string name)
        {
            for (int i = 0; i < deviceList.Count; i++)
            {
                if (deviceList[i].Name == name) return i;
            }
            return -1;
        }
    }
}
