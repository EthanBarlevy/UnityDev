using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] public List<GameObject> LifeObjects;

    public void OnLifeLost(float lives)
    {
        Debug.Log(lives);
        foreach (var obj in LifeObjects) 
        { 
            obj.GetComponent<Renderer>().enabled = false;
        }

        for (int i = 0; i < lives; i++)
        {
            LifeObjects[i].GetComponent<Renderer>().enabled = true;
        }
    }
}
