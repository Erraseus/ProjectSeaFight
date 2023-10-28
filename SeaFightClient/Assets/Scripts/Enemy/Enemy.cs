using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject indicator;
    [SerializeField] List<GameObject> ships;

    bool hasclicked = false;

    void OnMouseEnter()
    {
        indicator.SetActive(true);
    }

    void OnMouseExit()
    {
        if (!hasclicked)
        {
            indicator.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        hasclicked = true;
        indicator.SetActive(true);
        for (int i = 0; i < ships.Count; i++)
        {
            ships[i].GetComponent<Renderer>().material.color = Color.grey;
        }
    }
}