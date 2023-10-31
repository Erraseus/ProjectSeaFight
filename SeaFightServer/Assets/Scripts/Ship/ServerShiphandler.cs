using System.Collections.Generic;
using UnityEngine;

public class ServerShiphandler : MonoBehaviour
{
    [SerializeField] string databaseLocation;
    [SerializeField] Database database;
    [SerializeField] GameObject shipModel;
    [SerializeField] type Type;
    [Header("Current Ship Data")]
    [SerializeField] ShipSO currentShip;
    [SerializeField] int currentMaxHP;
    [SerializeField] int currentHP;
    [Space]
    [Header("Ship Slots")]
    [SerializeField] List<CannonSO> cannons = new List<CannonSO>();
    [SerializeField] List<SailSO> sails = new List<SailSO>();
    [SerializeField] List<CrewSO> crewMembers = new List<CrewSO>();



    public int sqlShipID = 1;
    
    [SerializeField] enum type { Player, Enemy, Npc}

    void Awake()
    {
        ResetShipData();
        database = GetDatabase(databaseLocation);
        LoadShipData(sqlShipID);
        UpdateShipData();
    }
    private void Update()
    {
        
    }

    Database GetDatabase(string location)
    {
        Database database;
        database = GameObject.Find(location).GetComponent<Database>();
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
    }
    
    void SaveShipData(int id)
    {
        sqlShipID = id;
    }
}