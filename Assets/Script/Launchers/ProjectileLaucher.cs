using UnityEngine;

public class ProjectileLaucher : MonoBehaviour, ILauncher
{
    [SerializeField] GameObject projectilePrefab;

    public void Launch(ShipGun shipGun)
    {
        var spawnedProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}
