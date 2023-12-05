using System;
using System.Collections.Generic;
using UnityEngine;

namespace Task_3_3.StaticData
{
    [CreateAssetMenu(fileName = "Tools", menuName = "Tool/Tools")]
    public class Tools : ScriptableObject
    {
        public List<Tool> AllTools;

        public Tool GetTool(ToolType type)
        {
            var tool = AllTools.Find(x => x.Type == type);

            if (tool == null)
            {
                throw new Exception($"Does not contains tool with type: {type}");
            }
            
            return tool;
        }
    }
}