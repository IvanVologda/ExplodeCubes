using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Cube cube, List<Rigidbody> spawnedObjects)
    {
        Vector3 explodePosition = cube.transform.position;
        Instantiate(_effect, explodePosition, Quaternion.identity);

        foreach (Rigidbody explodableObject in spawnedObjects)
        {
            explodableObject.AddExplosionForce(_explosionForce, explodePosition, _explosionRadius);
        }

    }
}
