using System.Collections.Generic;
using Task_3_2.MovePattern;
using UnityEngine;

namespace Task_3_2
{
    public class Task_3_2 : MonoBehaviour
    {
        [SerializeField] private Cloud _cloud;
        [SerializeField] private List<Transform> _targetPoints;
        [SerializeField] private float _offsetY;

        private void Awake()
        {
            _cloud.SetMover(new PointByPointMover(_cloud, _targetPoints, _offsetY));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _cloud.StartMove();
            }
        }
    }
}