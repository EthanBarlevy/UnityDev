using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerPlayer : MonoBehaviour
{
    private Vector3 force;
    private Rigidbody rb;
    [SerializeField] private float maxForce = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        force = direction * maxForce;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    { 
        rb.AddForce(force);
    }
}
