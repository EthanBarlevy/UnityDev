using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionEvent))]
public class GameEventManager : Interactable
{
    [SerializeField] EventRouter gameEvent;
    [SerializeField] bool oneTime = true;

    public override void OnInteract(GameObject target)
    {
        gameEvent?.Notify();
        if(interactFX != null) Instantiate(interactFX, transform.position, Quaternion.identity);
        if(destroyOnInteract) Destroy(gameObject);
    }
}
