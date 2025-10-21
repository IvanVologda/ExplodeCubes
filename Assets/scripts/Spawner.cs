using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private int _minCubes = 2;
    private int _maxCubes = 6;

    private float _factorChance = 0.5f;
    private float _factorScale = 0.5f;

    public event Action<Cube> ObjectSpawned;

    private List<Rigidbody> _spawnedCubes = new List<Rigidbody>();

    public IReadOnlyList<Rigidbody> SpawnedCubes => _spawnedCubes;

    public void Spawn(Cube cube)
    {
        _spawnedCubes.Clear();

        int spawnCount = UnityEngine.Random.Range(_minCubes, _maxCubes + 1);

        for(int i = 0; i < spawnCount; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, cube.transform.position, cube.transform.rotation);
            _spawnedCubes.Add(newCube.Rigidbody);

            Vector3 newScale = cube.transform.localScale * _factorScale;
            float newSplitChance = cube.SplitChance * _factorChance;
            
            newCube.Init(newSplitChance, newScale);

            ObjectSpawned?.Invoke(newCube);
        }
    }
}
