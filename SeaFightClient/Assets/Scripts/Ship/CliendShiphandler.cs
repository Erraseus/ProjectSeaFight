using System.Collections.Generic;
using UnityEngine;

public class CliendShiphandler : MonoBehaviour
{
    [SerializeField] string databaseLocation;
    [SerializeField] ClientDatabase database;
    [SerializeField] GameObject shipModel;
    [SerializeField] type Type;
    [Header("Current Ship Data")]
    [SerializeField] ShipSO currentShip;
    [SerializeField] int currentMaxHP;
    [SerializeField] int currentHP;
    [Space]
    [Space]
    [Space]
    [Header("Ship Slots")]
    [SerializeField] List<CannonSO> cannons = new List<CannonSO>();
    [SerializeField] List<SailSO> sails = new List<SailSO>();
    [SerializeField] List<CrewSO> crewMembers = new List<CrewSO>();
    
    int sqlShipID = 1;
    
    [SerializeField] enum type { Player, Enemy, Npc}

    void Awake()
    {
        ResetShipData();
        database = GetLocalDatabase(databaseLocation);
        LoadShipData(sqlShipID);
        UpdateShipData();
    }
    private void Update()
    {
        
    }

    ClientDatabase GetLocalDatabase(string location)
    {
        ClientDatabase database;
        database = GameObject.Find(location).GetComponent<ClientDatabase>();
        return database;
    }

    void ResetShipData()
    {
        currentShip = null;
        cannons.Clear();
        sails.Clear();
        crewMembers.Clear();
    }

    

    void LoadShipData(int id)
    {
        currentShip = database.ships[id];
    }
    void UpdateShipData()
    {
        currentMaxHP = currentShip.health;
        currentHP = currentMaxHP;
        for (int i = 0; i < currentShip.cannonSlots; i++) cannons.Add(null);
        for (int i = 0; i < currentShip.sailSlots; i++) sails.Add(null);
        for (int i = 0; i < currentShip.crewSlots; i++) crewMembers.Add(null);

        if (shipModel != null) Destroy(shipModel);

        shipModel = Instantiate(currentShip.Model, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
        shipModel.tag = Type.ToString();
        shipModel.transform.SetParent(transform);
    }
    
    void SaveShipData(int id)
    {
        sqlShipID = id;
    }
}