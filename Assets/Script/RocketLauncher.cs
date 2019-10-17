using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour, ILauncher
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireForce = 300f;

    public void Launch(ShipGun shipGun)
    {
        var spawnedProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Transform target = FindObjectOfType<Transform>();
    }
}

