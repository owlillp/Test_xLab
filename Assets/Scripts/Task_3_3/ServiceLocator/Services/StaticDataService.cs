using Task_3_3.StaticData;
using UnityEngine;

namespace Task_3_3.ServiceLocator.Services
{
    class StaticDataService : IStaticDataService
    { 
        private const string ToolsPath = "Tools";
        
        private Tools _allTools;

        public StaticDataService() => Load();

        public Tool GetTool(ToolType toolType) => _allTools.GetTool(toolType);
        
        private void Load() => _allTools = Resources.Load<Tools>(ToolsPath);
    }
}