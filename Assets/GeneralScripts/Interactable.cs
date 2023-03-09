using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public GameObject interactFX;
	public GameObject soundEffect;
	public bool destroyOnInteract = true;
	public Condition condition;

	public abstract void OnInteract(GameObject target);
}
