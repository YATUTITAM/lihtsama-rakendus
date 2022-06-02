namespace SystemInfo.Core.Devices.Memory.Space.Verifiers
{
    public sealed class MemoryDeviceSpaceVerifier : IMemoryDeviceSpaceVerifier
    {
        public bool Verify(IMemoryDeviceSpace memoryDeviceSpace, double maxOccupiedSpaceInPercentages)
        {
            if (memoryDeviceSpace == null)
            {
                throw new ArgumentNullException(nameof(memoryDeviceSpace));
            }

            return memoryDeviceSpace.OccupiedSpaceInPercentages > maxOccupiedSpaceInPercentages;
        }
    }
}
