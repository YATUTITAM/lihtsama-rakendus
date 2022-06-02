using SystemInfo.Core.Devices.Memory.Space;

namespace SystemInfo.Core.Devices.Memory
{
    public interface IMemoryDevice
    {
        double AvaliableFreeSpace { get; }

        double Capacity { get; }

        IMemoryDeviceSpace DeviceSpace { get; }
    }
}
