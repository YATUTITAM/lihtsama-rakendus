namespace SystemInfo.Core.Devices.Memory.Space.Calculators
{
    public interface IMemoryDeviceSpaceCalculator
    {
        double AvaliableFreeSpace { get; }

        double Capacity { get; }

        IMemoryDeviceSpace Calculate();
    }
}
