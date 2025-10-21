using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private ParticleSystem _effect;

    private void temporarilySpawnEffect(Vector3 position)
    {
        ParticleSystem effectInstance = Instantiate(_effect, position, Quaternion.identity);
        float totalDuration = effectInstance.main.duration + effectInstance.main.startLifetime.constantMax;

        Destroy(effectInstance.gameObject, totalDuration);
    }
    public void Explode(Cube cube, List<Rigidbody> spawnedObjects)
    {
        Vector3 explodePosition = cube.transform.position;

        foreach (Rigidbody explodableObject in spawnedObjects)
        {
            explodableObject.AddExplosionForce(_explosionForce, explodePosition, _explosionRadius);
        }

        temporarilySpawnEffect(explodePosition);
    }
}