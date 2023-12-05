using Task_3_3.StaticData;
using Task_3_3.ToolChangers;
using UnityEngine;

namespace Task_3_3
{
    public class Character : MonoBehaviour, IToolChangeable, IToolSelectable
    {
        [SerializeField] private MeshRenderer _toolMeshRenderer;
        [SerializeField] private MeshFilter _toolMeshFilter;
        private IToolChanger _toolChanger;
        private IPoolService<IToolChangeable> _poolService;

        private void Start()
        {
            _poolService = ServiceLocator.ServiceLocator.Container.Get<IPoolService<IToolChangeable>>();
            _poolService.Add(this);
            
            _toolChanger = new RandomToolChanger(this);
        }

        private void OnDestroy() => _poolService.Remove(this);

        public void ChangeTool() => _toolChanger.ChangeTool();

        public void SelectTool(Tool tool)
        {
            _toolMeshFilter.mesh = tool.Mesh;
            _toolMeshRenderer.material = tool.Material;
        }
    }
}