using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerEquipment playerStats;

    [SerializeField] GameObject cannonball;

    private void Start()
    {
        playerStats = GetComponent<PlayerEquipment>();
        StartCoroutine(ShootCannon());
    }

    IEnumerator ShootCannon()
    {
        while (true)
        {
            Instantiate(cannonball, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(playerStats.reloadTime);
        }
    }

    
}