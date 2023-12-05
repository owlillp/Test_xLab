using System;
using System.Collections.Generic;

namespace Task_3_3.ToolChangers
{
    public class PoolService<T> : IPoolService<T>
    {
        private List<T> _pool;

        public List<T> Pool => _pool;

        public PoolService() => _pool = new List<T>();

        public void Add(T obj)
        {
            if (_pool.Contains(obj))
            {
                throw new Exception("Try add character, which already contains in pool");
            }
            
            _pool.Add(obj);
        }

        public void Remove(T obj)
        {
            if (!_pool.Contains(obj))
            {
                throw new Exception("Try remove character, which doesnt contains in pool");
            }
            
            _pool.Remove(obj);
        }
    }
}