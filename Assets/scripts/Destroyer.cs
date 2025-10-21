using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
