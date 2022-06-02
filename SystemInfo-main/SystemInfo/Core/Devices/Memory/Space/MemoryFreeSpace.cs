namespace SystemInfo.Core.Devices.Memory.Space
{
    public sealed class MemoryFreeSpace : IMemoryDeviceSpace
    {
        public MemoryFreeSpace(double occupiedSpace, double occupiedSpaceInPercentages)
        {
            OccupiedSpace = occupiedSpace;
            OccupiedSpaceInPercentages = occupiedSpaceInPercentages;
        }



        public double OccupiedSpace { get; }

        public double OccupiedSpaceInPercentages { get; }
    }
}
