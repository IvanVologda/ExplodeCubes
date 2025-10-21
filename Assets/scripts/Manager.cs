using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Destroyer _destroyer;

    private void OnEnable()
    {
        _inputReader.CubeHitted += Control;
    }

    private void OnDisable()
    {
        _inputReader.CubeHitted -= Control;
    }

    private void Control(Cube cube)
    {
        _destroyer.DestroyCube(cube);

        if (cube.SplitChance > Random.value)
        {
            _spawner.Spawn(cube);
            _exploder.Explode(cube, (List<Rigidbody>)_spawner.SpawnedCubes);
        }
        else
        {
            _destroyer.DestroyCube(cube);
        }
    }
}
