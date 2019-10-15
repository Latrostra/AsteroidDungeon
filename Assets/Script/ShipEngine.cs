using System;
using UnityEngine;

public class ShipEngine : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float turnSpeed = 120f;

    private float lastThrust = float.MinValue;

    public event Action<float> ThrustChanged = delegate { };

    private ShipInput shipInput;
    // Start is called before the first frame update
    void Start()
    {
        shipInput = GetComponent<ShipInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lastThrust != shipInput.vertical)
        {
            ThrustChanged(shipInput.vertical);
        }

        lastThrust = shipInput.vertical;

        transform.position += shipInput.vertical * speed * transform.up * Time.deltaTime;
        transform.Rotate(-shipInput.horizontal * turnSpeed * transform.forward * Time.deltaTime);
    }
}
