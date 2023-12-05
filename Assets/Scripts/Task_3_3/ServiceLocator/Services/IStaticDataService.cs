using Task_3_3.StaticData;

namespace Task_3_3.ServiceLocator.Services
{
    public interface IStaticDataService : IService
    {
        Tool GetTool(ToolType toolType);
    }
}