using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private float _splitChance = 1.0f;
    private Rigidbody _rigidbody;

    public float SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(float splitChance, Vector3 scale)
    {
        _splitChance = splitChance;
        transform.localScale = scale;
    }
}
