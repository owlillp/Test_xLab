using System;
using System.Collections.Generic;
using UnityEngine;

namespace Task_3_2.MovePattern
{
    public class PointByPointMover : IMover
    {
        private const float MinDistanceToTarget = 0.05f;
        
        private readonly IMovable _movable;
        private readonly Queue<Transform> _targets;
        private readonly float _offset;

        private Transform _currentTarget;
        private bool _isMoving;
        
        public event Action MoveStopped;
        public event Action MoveStarted;

        public PointByPointMover(IMovable movable, IEnumerable<Transform> targets, float offset)
        {
            _movable = movable;
            _targets = new Queue<Transform>(targets);
            _offset = offset;
        }

        public void StartMove()
        {
            SwitchTarget();
            
            _isMoving = true;
            
            MoveStarted?.Invoke();
        }

        public void StopMove()
        {
            _isMoving = false;
            
            MoveStopped?.Invoke();
        }

        public void Update(float deltaTime)
        {
            if (!_isMoving)
            {
                return;
            }

            var targetPosition = _currentTarget.position + new Vector3( 0f, _offset, 0f);
            var direction = targetPosition - _movable.Transform.position;
            _movable.Transform.Translate(direction.normalized * _movable.Speed * deltaTime);
            
            if (direction.magnitude <= MinDistanceToTarget)
            {
                StopMove();
            }
        }

        private void SwitchTarget()
        {
            if(_currentTarget != null)
                _targets.Enqueue(_currentTarget);

            _currentTarget = _targets.Dequeue();
        }
    }
}