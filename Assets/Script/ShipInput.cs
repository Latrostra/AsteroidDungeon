using System;
using UnityEngine;

public class ShipInput : MonoBehaviour
{
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public bool isShooting { get; private set; }

    public event Action OnFire = delegate { };

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        isShooting = Input.GetButtonDown("Fire1");
        if (isShooting)
        {
            OnFire();
        }
    }
}
