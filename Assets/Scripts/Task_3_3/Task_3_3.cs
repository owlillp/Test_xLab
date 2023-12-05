using Task_3_3.ServiceLocator.Services;
using Task_3_3.ToolChangers;
using UnityEngine;

namespace Task_3_3
{
    public class Task_3_3 : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.ServiceLocator.Container.Register<IStaticDataService>(new StaticDataService());
            ServiceLocator.ServiceLocator.Container.Register<IPoolService<IToolChangeable>>(new PoolService<IToolChangeable>());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var toolChangeables = ServiceLocator.ServiceLocator.Container.Get<IPoolService<IToolChangeable>>().Pool;
                
                foreach (var toolChangeable in toolChangeables)
                {
                    toolChangeable.ChangeTool();
                }
            }
        }
    }
}