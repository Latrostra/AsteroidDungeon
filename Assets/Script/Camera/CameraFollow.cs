using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float followSpeed = 1f;
    [SerializeField] Transform target;

    private void Update()
    {
        Vector3 newPos = target.position;
        newPos.z = -10f;
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed);
    }
}
