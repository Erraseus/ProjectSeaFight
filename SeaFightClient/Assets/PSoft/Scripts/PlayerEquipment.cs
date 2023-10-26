using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] ShipSO ship;
    [SerializeField] List<CannonSO> cannons = new List<CannonSO>();
    [SerializeField] List<SailSO> sails = new List<SailSO>();
    [SerializeField] List<CrewSO> crewMembers = new List<CrewSO>();

    private void Awake()
    {
        BuildShip();
    }

    void BuildShip()
    {
        //TODO: Get this from Database//
        ship = GameObject.Find("Database").GetComponent<ComponentData>().ships[0];

        for (int i = 0; i < ship.cannonSlots; i++)
        {
            cannons.Add(GameObject.Find("Database").GetComponent<ComponentData>().cannons[0]);
        }
        for (int i = 0; i < ship.sailSlots; i++)
        {
            sails.Add(GameObject.Find("Database").GetComponent<ComponentData>().sails[0]);
        }
        for (int i = 0; i < ship.crewSlots; i++)
        {
            crewMembers.Add(GameObject.Find("Database").GetComponent<ComponentData>().crewMembers[0]);
        }
        //TODO: End
    }
}