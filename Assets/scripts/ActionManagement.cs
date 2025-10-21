using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManagement : MonoBehaviour
{
    [SerializeField] private RayThrower _rayThrower;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Destroyer _destroyer;

    private void OnEnable()
    {
        _rayThrower.CubeHitted += Control;
    }

    private void OnDisable()
    {
        _rayThrower.CubeHitted -= Control;
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
