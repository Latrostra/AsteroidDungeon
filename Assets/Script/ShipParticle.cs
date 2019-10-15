using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParticle : MonoBehaviour
{
    [SerializeField] private GameObject particleThrustPrefab;

    ParticleSystem.EmissionModule ps;

    private void Awake()
    {
        GetComponentInParent<ShipEngine>().ThrustChanged += HandleThrustChanged;
        ps = particleThrustPrefab.GetComponent<ParticleSystem>().emission;
    }

    private void HandleThrustChanged(float thrust)
    {
        ps.rateOverTime = thrust * 10;
    }
}
