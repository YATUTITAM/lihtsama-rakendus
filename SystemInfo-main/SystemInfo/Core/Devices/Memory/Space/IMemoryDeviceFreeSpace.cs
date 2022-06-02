namespace SystemInfo.Core.Devices.Memory.Space
{
    public interface IMemoryDeviceSpace
    {
        double OccupiedSpace { get; }

        double OccupiedSpaceInPercentages { get; }
    }
}
