using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float fireForce = 300f;
    
    void Start()
    {
        Rigidbody2D rbSpawnedProjectile = this.GetComponent<Rigidbody2D>();
        rbSpawnedProjectile.AddForce(this.transform.up * fireForce);
    }
}
