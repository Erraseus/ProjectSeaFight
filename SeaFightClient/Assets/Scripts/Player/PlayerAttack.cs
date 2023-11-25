using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerEquipment playerStats;
    [SerializeField] GameObject cannonball;

    [SerializeField] List<GameObject> enemies;

    bool attackState = false;

    Vector3 attackRangeIndicator;
    private void Start()
    {
        transform.localScale = attackRangeIndicator;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }
    private void Update()
    {
        if (enemies.Count > 0 && !attackState)
        {
            attackState = true;
            
        }
        if (enemies.Count <= 0 && attackState)
        {
            attackState = false;
        }
    }
}