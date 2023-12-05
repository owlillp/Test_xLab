using System;
using Task_3_2.MovePattern;
using UnityEngine;

namespace Task_3_2
{
    public class Cloud : MonoBehaviour, IMovable
    {
        [Range(0f, 20f), SerializeField] private float _speed;
        [SerializeField] private ParticleSystem _rainParticleSystem;
        
        private IMover _mover;

        public Transform Transform => transform;
        public float Speed => _speed;

        private void Awake() => _rainParticleSystem.Stop();
        
        private void OnDestroy() => DisposeMover();

        private void Update() => _mover?.Update(Time.deltaTime);

        public void StartMove() => _mover?.StartMove();

        public void SetMover(IMover mover)
        {
            DisposeMover();
            
            _mover = mover;
            
            _mover.MoveStarted += OnMoveStarted;
            _mover.MoveStopped += OnMoveStopped;
        }

        private void DisposeMover()
        {
            if (_mover != null)
            {
                _mover.StopMove();
                
                _mover.MoveStarted -= OnMoveStarted;
                _mover.MoveStopped -= OnMoveStopped;
            }
        }

        private void OnMoveStarted() => _rainParticleSystem.Stop();

        private void OnMoveStopped() => _rainParticleSystem.Play();
    }
}