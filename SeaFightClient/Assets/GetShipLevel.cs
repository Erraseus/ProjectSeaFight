using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetShipLevel : MonoBehaviour
{
    [SerializeField] ShipSO shipLevel;
    [SerializeField] PlayerEquipment playerEquipment;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerEquipment = other.GetComponentInParent<PlayerEquipment>();
            if (playerEquipment.shipLevel != shipLevel.id)
            {
                playerEquipment.shipLevel = shipLevel.id;

                playerEquipment.ChangeShip(shipLevel.id, other.gameObject);
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        playerEquipment = null;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
