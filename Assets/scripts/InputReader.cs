using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Ray _ray;
    public event Action<Cube> CubeHitted;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CastRay();
    }

    private void CastRay()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(_ray, out hit))
        {
            if(hit.collider.TryGetComponent<Cube>(out Cube cube))
            {
                Debug.Log($"Hitted cube at position: {cube.transform.position}");
                CubeHitted?.Invoke(cube);
            }
        }
    }
}
