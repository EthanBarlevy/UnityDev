using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionEvent))]
public class Checkpoint : Interactable
{
    void Start()
    {
        GetComponent<CollisionEvent>().onEnter += OnInteract;
    }

    public override void OnInteract(GameObject target)
    {
        if (target.TryGetComponent<RollerGameManager>(out RollerGameManager manager))
        {
            manager.OnCheckpointGet(transform);
        }

        if (interactFX != null) Instantiate(interactFX, transform.position, Quaternion.identity);
        if (destroyOnInteract) Destroy(gameObject);
    }
}
