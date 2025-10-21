using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayThrower : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Ray _ray;

    public event Action<Cube> CubeHitted;

    private void OnEnable()
    {
        _inputReader.CubeClicked += CastRay;
    }
    private void OnDisable()
    {
        _inputReader.CubeClicked -= CastRay;
    }

    private void CastRay()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube cube))
            {
                Debug.Log($"Hitted cube at position: {cube.transform.position}");
                CubeHitted?.Invoke(cube);
            }
        }
    }
}
