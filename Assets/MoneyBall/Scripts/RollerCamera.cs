using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField, Range(1, 10)] private float distance = 10;
    [SerializeField, Range(20, 80)] private float pitch;
    [SerializeField, Range(0.1f, 5)] private float sensitivity;

    private float yaw = 0;

    void LateUpdate()
    {
        if (target == null) return;

        yaw += Input.GetAxis("Mouse X") * sensitivity;
        Quaternion qYaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qPitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion rotation = qYaw * qPitch;

        Vector3 offset = rotation * Vector3.back * distance;

        transform.position = target.position + offset;
        transform.rotation = Quaternion.LookRotation(-offset);
    }

    public void setTarget(Transform target)
    { 
        this.target = target;
        yaw = target.rotation.eulerAngles.y;
    }
}
