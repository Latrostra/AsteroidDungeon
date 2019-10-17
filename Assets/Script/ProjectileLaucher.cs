using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaucher : MonoBehaviour, ILauncher
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireForce = 300f;

    public void Launch(ShipGun shipGun)
    {
        var spawnedProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody2D rbSpawnedProjectile = spawnedProjectile.GetComponent<Rigidbody2D>();
        rbSpawnedProjectile.AddForce(spawnedProjectile.transform.up * fireForce);
    }
}
