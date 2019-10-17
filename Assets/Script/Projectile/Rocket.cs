using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Vector3 target;

    void Start()
    {
        target = SetTarget();
    }

    void Update()
    {
        MoveToTarget(target);
    }

    private Vector3 SetTarget()
    {
        return FindObjectOfType<Enemy>().transform.position;
    }

    private void MoveToTarget(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 2f * Time.deltaTime);
    }
}
