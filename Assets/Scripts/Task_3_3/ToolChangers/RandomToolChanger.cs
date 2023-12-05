using System;
using Task_3_3.StaticData;

namespace Task_3_3.ToolChangers
{
    public class RandomToolChanger : ToolChanger
    {
        private readonly IToolSelectable _toolSelectable;

        public RandomToolChanger(IToolSelectable toolSelectable) 
            => _toolSelectable = toolSelectable;

        public override void ChangeTool()
        {
            var toolType = GetRandomToolType();
            var tool = StaticDataService.GetTool(toolType);

            _toolSelectable.SelectTool(tool);
        }

        private ToolType GetRandomToolType() 
            => (ToolType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(ToolType)).Length);
    }
}