using Task_3_3.ServiceLocator.Services;
using Task_3_3.ToolChangers;
using UnityEngine;

namespace Task_3_3
{
    public class Task_3_3 : MonoBehaviour
    {
        private IPoolService<IToolChangeable> _poolService;
        
        private void Awake()
        {
            ServiceLocator.ServiceLocator.Container.Register<IStaticDataService>(new StaticDataService());
            _poolService = ServiceLocator.ServiceLocator.Container.Register<IPoolService<IToolChangeable>>(new PoolService<IToolChangeable>());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var toolChangeables = _poolService.Pool;
                
                foreach (var toolChangeable in toolChangeables)
                {
                    toolChangeable.ChangeTool();
                }
            }
        }
    }
}