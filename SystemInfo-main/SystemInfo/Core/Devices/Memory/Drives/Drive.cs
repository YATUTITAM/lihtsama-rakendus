using SystemInfo.Core.Devices.Memory.Base;
using SystemInfo.Core.Devices.Memory.Designated;

namespace SystemInfo.Core.Devices.Drives
{
    public sealed class Drive : MemoryDeviceBase, IDesignatedMemoryDevice
    {
        public Drive(string name, double avaliableFreeSpace, double capacity) : base(avaliableFreeSpace, capacity)
        {
            Name = name;
        }



        public string Name { get; }
    }
}
