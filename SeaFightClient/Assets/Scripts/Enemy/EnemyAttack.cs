using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyEquipment playerStats;
    [SerializeField] GameObject cannonball;

    [SerializeField] List<GameObject> players;

    bool attackState = false;

    Vector3 attackRangeIndicator;
    private void Start()
    {
        attackRangeIndicator = new Vector3(playerStats.attackRange, transform.localScale.y, playerStats.attackRange);

        transform.localScale = attackRangeIndicator;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            players.Add(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            players.Remove(other.gameObject);
        }
    }
    private void Update()
    {
        if (players.Count > 0 && !attackState)
        {
            attackState = true;
            StartCoroutine(ShootCannon());
        }
        if (players.Count <= 0 && attackState)
        {
            attackState = false;
            StopAllCoroutines();
        }
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
