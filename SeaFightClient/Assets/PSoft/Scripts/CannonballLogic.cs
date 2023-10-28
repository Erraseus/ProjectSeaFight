using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CannonballLogic : MonoBehaviour
{
    PlayerEquipment playerStats;
    Transform target;
    [SerializeField] GameObject damageTextObject;
    [SerializeField] float speed;
    Transform facingCamera;
    Vector3 targetPosition;
    bool coroutineStarted = false;

    void Awake()
    {
        facingCamera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerEquipment>();
        target = GameObject.Find("Kevin").GetComponent<Transform>();
        targetPosition = new Vector3(target.transform.position.x + Random.Range(-0.5f, 0.5f), target.transform.position.y + Random.Range(0.5f, 1f), target.transform.position.z + Random.Range(-0.5f, 0.5f));
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (coroutineStarted)
        {
            damageTextObject.transform.rotation = facingCamera.transform.rotation;
            damageTextObject.transform.Translate(3f * Time.deltaTime * Vector3.up);
        }
        

        if (transform.position == targetPosition && !coroutineStarted)
        {
            coroutineStarted = true;
            GetComponent<MeshRenderer>().enabled = false;

            float minDamage = playerStats.damage * 0.95f;
            float maxdamage = playerStats.damage;
            float calculatedDamage = Random.Range(minDamage, maxdamage);


            float normalDamage = Mathf.Round(calculatedDamage);
            float criticalDamage = Mathf.Round(calculatedDamage * 1.25f);


            float calculatetHitChance = Random.Range(0f, 100f);
            float calculatedCritChance = Random.Range(0f, 100f);
            if (playerStats.hitChance >= calculatetHitChance)
            {


                if (playerStats.critChance >= calculatedCritChance)
                {
                    damageTextObject.GetComponent<TextMesh>().color = Color.red;
                    StartCoroutine(DamageText($"CRIT {criticalDamage}!", damageTextObject));
                }
                else
                {
                    damageTextObject.GetComponent<TextMesh>().color = Color.yellow;
                    StartCoroutine(DamageText($"HIT {normalDamage}", damageTextObject));
                }
                
            }
            else
            {
                StartCoroutine(DamageText("MISS!", damageTextObject));
            }
        }

        IEnumerator DamageText(string damageInformation, GameObject damageTextObject)
        {
            damageTextObject.GetComponent<TextMesh>().text = damageInformation;
            damageTextObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
        }
    }
}