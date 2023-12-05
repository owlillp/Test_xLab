using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool<T> where T : MonoBehaviour
{
   public T Prefab { get; }
   public bool AutoExpand { get; }
   public Transform Container { get; }

   private List<T> _pool;

   public ObjectPool(T prefab, Transform container, int count, bool autoExpand)
   {
      AutoExpand = autoExpand;
      Prefab = prefab;
      Container = container;
      
      CreatePool(count);
   }

   private void CreatePool(int count)
   {
      _pool = new List<T>();

      for (int i = 0; i < count; i++)
      {
         CreateObject();
      }
   }

   private T CreateObject(bool isActive = false)
   {
      var createdObject = Object.Instantiate(Prefab, Container);
      createdObject.gameObject.SetActive(isActive);
      
      _pool.Add(createdObject);

      return createdObject;
   }

   public bool HasFreeElement(out T element)
   {
      foreach (var poolObject in _pool)
      {
         if (!poolObject.gameObject.activeSelf)
         {
            element = poolObject;
            poolObject.gameObject.SetActive(true);
            return true;
         }
      }

      element = null;
      return false;
   }

   public T GetFreeElement()
   {
      if (HasFreeElement(out var element))
      {
         return element;
      }

      if (AutoExpand)
      {
         return CreateObject(true);
      }

      throw new Exception($"No free element in pool {typeof(T)}");
   }
}
