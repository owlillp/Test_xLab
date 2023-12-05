using System;

namespace Task_3_2.MovePattern
{
    public interface IMover
    {
        void StartMove();
        void StopMove();
        void Update(float deltaTime);
        event Action MoveStopped;
        event Action MoveStarted;
    }
}