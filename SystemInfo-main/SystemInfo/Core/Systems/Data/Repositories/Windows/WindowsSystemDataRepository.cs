using System.Management;
using SystemInfo.Core.Devices.Drives;
using SystemInfo.Core.Devices.RAM;
using SystemInfo.Core.Systems.Data.Result;

namespace SystemInfo.Core.Systems.Data.Repositories.Windows
{
    public sealed class WindowsSystemDataRepository : ISystemDataRepository
    {
        public ISystemDataResult ReadData()
        {
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectCollection managementObjects = new ManagementObjectSearcher(query).Get();

            double memoryInUse = default;
            double memoryCapacity = default;
            foreach (ManagementObject managementObject in managementObjects)
            {
                memoryCapacity = double.Parse(managementObject["TotalVisibleMemorySize"].ToString());
                memoryInUse = memoryCapacity - double.Parse(managementObject["FreePhysicalMemory"].ToString());
            }

            IList<Drive> drives = new List<Drive>();
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                if (driveInfo.IsReady)
                {
                    drives.Add(new Drive(driveInfo.Name, driveInfo.AvailableFreeSpace, driveInfo.TotalSize));
                }
            }

            return new SystemDataResult(new RAM(memoryInUse, memoryCapacity), drives);
        }
    }
}
