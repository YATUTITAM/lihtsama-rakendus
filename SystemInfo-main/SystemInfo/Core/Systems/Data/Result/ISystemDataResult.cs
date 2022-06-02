using SystemInfo.Core.Devices.Drives;
using SystemInfo.Core.Devices.RAM;

namespace SystemInfo.Core.Systems.Data.Result
{
    public interface ISystemDataResult
    {
        RAM Memory { get; }

        IEnumerable<Drive> Drives { get; }
    }
}
