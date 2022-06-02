namespace SystemInfo.Core.Devices.Memory.Space.Verifiers
{
    public interface IMemoryDeviceSpaceVerifier
    {
        bool Verify(IMemoryDeviceSpace memoryDeviceSpace, double maxOccupiedSpaceInPercentages);
    }
}
