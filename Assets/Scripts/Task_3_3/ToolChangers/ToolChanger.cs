using Task_3_3.ServiceLocator.Services;

namespace Task_3_3.ToolChangers
{
    public abstract class ToolChanger : IToolChanger
    {
        protected readonly IStaticDataService StaticDataService;

        protected ToolChanger() =>
            StaticDataService = ServiceLocator.ServiceLocator.Container.Get<IStaticDataService>();

        public abstract void ChangeTool();
    }
}