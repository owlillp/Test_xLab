using System;

namespace Task_3_2.MovePattern
{
    public class NoMovePattern :  IMover
    {
        public void StartMove() { }

        public void StopMove() { }

        public void Update(float deltaTime) { }
        public event Action MoveStopped;
        public event Action MoveStarted;
    }
}