using SystemInfo.Core.Devices.Memory.Base;

namespace SystemInfo.Core.Devices.RAM
{
    public sealed class RAM : MemoryDeviceBase
    {
        public RAM(double inUse, double totalSpace) : base(inUse, totalSpace)
        {
        }
    }
}
