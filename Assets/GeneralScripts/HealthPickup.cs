using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollisionEvent))]
public class HealthPickup : Interactable
{
	[SerializeField] private float healAmount;

	private void Start()
	{
		GetComponent<CollisionEvent>().onEnter += OnInteract;
	}

	public override void OnInteract(GameObject target)
	{
		if (target.TryGetComponent<Health>(out Health health))
		{
			health.OnApplyHealth(healAmount);
		}

		if (interactFX != null) Instantiate(interactFX, transform.position, Quaternion.identity);
		if (destroyOnInteract) Destroy(gameObject);
	}
}
