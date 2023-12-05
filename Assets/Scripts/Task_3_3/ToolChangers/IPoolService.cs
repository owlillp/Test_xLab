using System.Collections.Generic;
using Task_3_3.ServiceLocator.Services;

namespace Task_3_3.ToolChangers
{
    public interface IPoolService<T> : IService
    {
        List<T> Pool { get; }
        public void Add(T obj);
        public void Remove(T obj);
    }
}