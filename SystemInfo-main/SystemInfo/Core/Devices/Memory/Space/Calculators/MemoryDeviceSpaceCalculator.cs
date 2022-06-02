namespace SystemInfo.Core.Devices.Memory.Space.Calculators
{
    public sealed class MemoryDeviceSpaceCalculator : IMemoryDeviceSpaceCalculator
    {
        public MemoryDeviceSpaceCalculator(double avaliableFreeSpace, double capacity)
        {
            AvaliableFreeSpace = avaliableFreeSpace;
            Capacity = capacity;
        }



        public IMemoryDeviceSpace Calculate()
        {
            double occupiedSpace = Capacity - AvaliableFreeSpace;
            double occupiedSpaceInPercentages = (Capacity - occupiedSpace) / Capacity * 100;
            return new MemoryFreeSpace(occupiedSpace, occupiedSpaceInPercentages);
        }



        public double AvaliableFreeSpace { get; }
               
        public double Capacity { get; }
    }
}
