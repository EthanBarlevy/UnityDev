using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

[RequireComponent(typeof(CollisionEvent))]
public class Lives : MonoBehaviour
{
    [SerializeField] public List<GameObject> LifeObjects;

    public Action onLifeLost;

    public void OnLifeLost(float lives)
    {
        foreach (var obj in LifeObjects) 
        { 
            obj.SetActive(false);
        }

        for (int i = 0; i < lives; i++) 
        {
            LifeObjects[i].gameObject.SetActive(true);
        }
    }
}
