using System;
using System.Collections.Generic;
using Task_3_3.ServiceLocator.Services;
using UnityEngine;

namespace Task_3_3.ServiceLocator
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance;
        public static ServiceLocator Container => _instance ??= new ServiceLocator();
        
        private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        public T Register<T>(T service) where T : IService
        {
            if (_services.ContainsKey(typeof(T)))
            {
                Debug.Log($"Attempted to register service {typeof(T)}, which already contains ");
                return (T)_services[typeof(T)];
            }
            
            _services.Add(typeof(T), service);
            return service;
        }

        public void Unregister<T>() where T : IService
        {
            if (!_services.ContainsKey(typeof(T)))
            {
                Debug.Log($"Attempted to unregister same service {typeof(T)}, which doesnt contains ");
                return;
            }
            
            _services.Remove(typeof(T));
        }

        public T Get<T>() where T : IService
        {
            if (!_services.ContainsKey(typeof(T)))
            {
                throw new Exception($"Attempted to register service {typeof(T)}, which doesnt contains ");
            }

            return (T)_services[typeof(T)];
        }
    }
}