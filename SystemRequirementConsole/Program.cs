using Newtonsoft.Json;
using System;
using System.Linq;
using System.Management;
using SystemRequirementConsole.Model;

namespace SystemRequirementConsole
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            var OperatingSystemSearcherObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem").Get().Cast<ManagementObject>().FirstOrDefault();
            var CPUSearcherObject = new ManagementObjectSearcher("select * from Win32_Processor").Get().Cast<ManagementObject>().FirstOrDefault();
            #region CPU Scan
            var CPUModel = new CPU();
            CPUModel.Id = (string)CPUSearcherObject["ProcessorId"];
            CPUModel.Socket = (string)CPUSearcherObject["SocketDesignation"];
            CPUModel.Name = (string)CPUSearcherObject["Name"];
            CPUModel.Description = (string)CPUSearcherObject["Caption"];
            CPUModel.AddressWidth = (ushort)CPUSearcherObject["AddressWidth"];
            CPUModel.DataWidth = (ushort)CPUSearcherObject["DataWidth"];
            CPUModel.Architecture = (ushort)CPUSearcherObject["Architecture"];
            CPUModel.SpeedMHz = (uint)CPUSearcherObject["MaxClockSpeed"];
            CPUModel.BusSpeedMHz = (uint)CPUSearcherObject["ExtClock"];
            CPUModel.L2Cache = (uint)CPUSearcherObject["L2CacheSize"] * (ulong)1024;
            CPUModel.L3Cache = (uint)CPUSearcherObject["L3CacheSize"] * (ulong)1024;
            CPUModel.Cores = (uint)CPUSearcherObject["NumberOfCores"];
            CPUModel.Threads = (uint)CPUSearcherObject["NumberOfLogicalProcessors"];
            #endregion

            #region Memory Scan
            var MemoryModel = new Memory();
            string Query = "SELECT MaxCapacity FROM Win32_PhysicalMemoryArray";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);
            foreach (ManagementObject WniPART in searcher.Get())
            {
                UInt32 SizeinKB = Convert.ToUInt32(WniPART.Properties["MaxCapacity"].Value);
                UInt32 SizeinMB = SizeinKB / 1024;
                UInt32 SizeinGB = SizeinMB / 1024;
                Console.WriteLine("Size in KB: {0}, Size in MB: {1}, Size in GB: {2}", SizeinKB, SizeinMB, SizeinGB);
            }
            #endregion

            #region Video Card

            var videoCardModel = new VideoCard();
            ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject obj in objvide.Get())
            {
                Console.WriteLine("Name  -  " + obj["Name"] + "</br>");
                Console.WriteLine("DeviceID  -  " + obj["DeviceID"] + "</br>");
                Console.WriteLine("AdapterRAM  -  " + obj["AdapterRAM"] + "</br>");
                Console.WriteLine("AdapterDACType  -  " + obj["AdapterDACType"] + "</br>");
                //Console.WriteLine("Monochrome  -  " + obj["Monochrome"] + "</br>");
                //Console.WriteLine("InstalledDisplayDrivers  -  " + obj["InstalledDisplayDrivers"] + "</br>");
                //Console.WriteLine("DriverVersion  -  " + obj["DriverVersion"] + "</br>");
                Console.WriteLine("VideoProcessor  -  " + obj["VideoProcessor"] + "</br>");
                Console.WriteLine("VideoArchitecture  -  " + obj["VideoArchitecture"] + "</br>");
                Console.WriteLine("VideoMemoryType  -  " + obj["VideoMemoryType"] + "</br>");
            }

            #endregion

            #region send Request to Server
            var sz = JsonConvert.SerializeObject(CPUModel);
            Console.WriteLine(sz);


            #endregion
        }
    }
}
