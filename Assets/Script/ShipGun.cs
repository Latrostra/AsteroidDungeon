using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGun : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireForce = 300f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<ShipInput>().OnFire += Shoot;
    }

    private void Shoot()
    {
        var spawnedProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody2D rbSpawnedProjectile = spawnedProjectile.GetComponent<Rigidbody2D>();
        rbSpawnedProjectile.AddForce(spawnedProjectile.transform.up * fireForce);
    }
}
