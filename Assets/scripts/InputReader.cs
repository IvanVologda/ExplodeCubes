using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action CubeClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CubeClicked?.Invoke();
    }
}
