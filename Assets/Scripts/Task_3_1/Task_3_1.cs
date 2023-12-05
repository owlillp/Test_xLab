using UnityEngine;

public class Task_3_1 : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _poolContainer;
    [SerializeField] private FallingStone _stonePrefab;
    [Range(0, 10), SerializeField] private int _startStoneCount;

    private StoneSpawner _stoneSpawner;

    private void Awake()
    {
        _stoneSpawner = new StoneSpawner(_spawnPoint, _stonePrefab, _poolContainer, _startStoneCount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _stoneSpawner.Spawn();
        }
    }
}
