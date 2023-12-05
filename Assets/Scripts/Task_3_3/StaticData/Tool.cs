using UnityEngine;

namespace Task_3_3.StaticData
{
    [CreateAssetMenu(fileName = "Tool", menuName = "Tool/Tool")]
    public class Tool : ScriptableObject
    {
        public ToolType Type;
        public Mesh Mesh;
        public Material Material;
    }
}