using SystemInfo.Core.Systems.Data.Result;

namespace SystemInfo.Core.Systems.Data.Repositories
{
    public interface ISystemDataRepository
    {
        ISystemDataResult ReadData();
    }
}
