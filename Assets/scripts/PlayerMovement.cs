using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw(Horizontal), 0f, Input.GetAxisRaw(Vertical));
        transform.position += direction * _moveSpeed * Time.deltaTime;
    }
}
