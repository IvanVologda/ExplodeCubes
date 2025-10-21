using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorer : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.ObjectSpawned += SetRandomColor;
    }

    private void OnDisable()
    {
        _spawner.ObjectSpawned -= SetRandomColor;
    }

    private void SetRandomColor(Cube cube)
    {
        MeshRenderer meshRenderer = cube.GetComponent<MeshRenderer>();

        meshRenderer.material.color = Random.ColorHSV();
    }
}
