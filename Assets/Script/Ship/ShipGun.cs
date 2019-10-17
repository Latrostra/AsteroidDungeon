using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGun : MonoBehaviour
{

    private ILauncher launcher;

    void Awake()
    {
        launcher = GetComponent<ILauncher>();
    }

    void Start()
    {
        GetComponentInParent<ShipInput>().OnFire += Shoot;
    }

    private void Shoot()
    {
        launcher.Launch(this);
    }


}
