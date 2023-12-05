using UnityEngine;

public class StoneSpawner
{
   private Transform _spawnPoint;
   private ObjectPool<FallingStone> _objectPool;

   public StoneSpawner(Transform spawnPoint, FallingStone prefab, Transform container, int startCount)
   {
      _objectPool = new ObjectPool<FallingStone>(prefab, container, startCount, true);
      _spawnPoint = spawnPoint;
   }

   public void Spawn()
   {
      var targetStone = _objectPool.GetFreeElement();
      
      targetStone.transform.SetPositionAndRotation(_spawnPoint.position, _spawnPoint.rotation);
   }
}
