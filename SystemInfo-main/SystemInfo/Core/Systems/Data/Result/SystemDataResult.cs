using SystemInfo.Core.Devices.Drives;
using SystemInfo.Core.Devices.RAM;

namespace SystemInfo.Core.Systems.Data.Result
{
    public sealed class SystemDataResult : ISystemDataResult
    {
        public SystemDataResult(RAM memory, IEnumerable<Drive> drives)
        {
            Memory = memory ?? throw new ArgumentNullException(nameof(memory));
            Drives = drives ?? throw new ArgumentNullException(nameof(drives));
        }



        public RAM Memory { get; }

        public IEnumerable<Drive> Drives { get; }
    }
}
