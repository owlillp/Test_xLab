using UnityEngine;

namespace Task_3_2
{
    public interface IMovable
    {
        Transform Transform { get; }
        float Speed { get; }
    }
}