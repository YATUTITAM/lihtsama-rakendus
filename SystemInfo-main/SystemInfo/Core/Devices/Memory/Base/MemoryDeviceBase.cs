using SystemInfo.Core.Devices.Memory.Space;
using SystemInfo.Core.Devices.Memory.Space.Calculators;

namespace SystemInfo.Core.Devices.Memory.Base
{
    public abstract class MemoryDeviceBase : IMemoryDevice
    {
        protected MemoryDeviceBase(double avaliableFreeSpace, double capacity)
        {
            AvaliableFreeSpace = avaliableFreeSpace;
            Capacity = capacity;
            DeviceSpace = new MemoryDeviceSpaceCalculator(avaliableFreeSpace, capacity).Calculate();
        }



        public double AvaliableFreeSpace { get; }

        public double Capacity { get; }

        public IMemoryDeviceSpace DeviceSpace { get; }
    }
}
