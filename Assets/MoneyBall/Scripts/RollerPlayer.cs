using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RollerPlayer : MonoBehaviour
{
    [SerializeField] private float maxForce = 5;
    [SerializeField] private Transform view;

    private Vector3 force;
    private Rigidbody rb;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        Quaternion viewSpace = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);
        force = viewSpace * direction * maxForce;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    { 
        rb.AddForce(force);
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log(score);
    }
}
