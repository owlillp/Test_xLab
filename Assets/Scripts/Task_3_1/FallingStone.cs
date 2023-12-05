using UnityEngine;

public class FallingStone : MonoBehaviour
{
   [SerializeField] private float _disablingDistance = -10f;

   private void Update()
   {
      if (transform.position.y < _disablingDistance)
      {
         gameObject.SetActive(false);
      }
   }
}
