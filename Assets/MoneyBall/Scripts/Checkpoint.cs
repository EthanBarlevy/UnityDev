using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionEvent))]
public class Checkpoint : MonoBehaviour
{
    [SerializeField] Transform StartLocation;

    public Action onNewCheckpoint;

    public void OnCheckpointGet(Transform transform)
    {
        StartLocation = transform;
    }
}
