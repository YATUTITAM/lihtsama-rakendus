using SystemInfo.Core.Devices.Memory.Space.Verifiers;

namespace SystemInfo.Core.Devices.Verifiers
{
    public sealed class RegisteredVerifiers
    {
        public static readonly IMemoryDeviceSpaceVerifier MemoryDeviceSpaceVerifier = new MemoryDeviceSpaceVerifier();
    }
}
