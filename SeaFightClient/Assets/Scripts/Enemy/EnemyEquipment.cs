using System.Collections.Generic;
using UnityEngine;

public class EnemyEquipment : MonoBehaviour
{
    [Header("DataManager")]
    [SerializeField] ItemDataManager shipComponent;
    [SerializeField] int enemyLevel;
    [Space]
    [SerializeField] ShipSO ship;
    [SerializeField] List<CannonSO> cannons = new List<CannonSO>();
    [SerializeField] List<SailSO> sails = new List<SailSO>();
    [SerializeField] List<CrewSO> crewMembers = new List<CrewSO>();
    [Space]
    [Header("Ship Data")]
    [SerializeField] int maxHp = 0;
    [SerializeField] int currentHP = 0;
    [Space]
    [SerializeField] float sight = 0f;
    [Space]
    [Header("Cannon Data")]
    public int damage = 0;
    public float attackRange = 0f;
    public float reloadTime = 0f;
    public float hitChance = 0f;
    public float critChance = 0f;
    [Space]
    [Header("Sails Data")]
    [SerializeField] float speed = 0f;

    void Awake()
    {
        shipComponent = GameObject.Find("DataManager").GetComponent<ItemDataManager>();

        InitialiseShip();
        CalculateCannon();
        CalculateSail();
        CalculateCrew();
    }

    void InitialiseShip()
    {
        ship = shipComponent.ships[enemyLevel];

        for (int i = 0; i < ship.CannonSlots; i++)
        {
            cannons.Add(shipComponent.cannons[0]);
        }
        for (int i = 0; i < ship.SailSlots; i++)
        {
            sails.Add(shipComponent.sails[0]);
        }
        for (int i = 0; i < ship.CrewSlots; i++)
        {
            crewMembers.Add(shipComponent.crewMembers[0]);
        }

        maxHp = ship.Health;
        currentHP = ship.Health;
        sight = ship.Sight;

        GameObject shipModel = Instantiate(ship.Model, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
        shipModel.tag = "Enemy";
        shipModel.transform.SetParent(this.transform);
    }

    void CalculateCannon()
    {
        damage = 0;
        attackRange = 0;
        reloadTime = 0;
        hitChance = 0;
        critChance = 0;

        foreach (var cannon in cannons)
        {
            damage += cannon.Damage;
            attackRange += cannon.Range;
            reloadTime += cannon.ReloadTime;
            hitChance += cannon.Hitchance;
            critChance += cannon.Critchance;
        }
        if (cannons.Count > 0)
        {
            attackRange /= cannons.Count;
            reloadTime /= cannons.Count;
            hitChance /= cannons.Count;
            critChance /= cannons.Count;
        }
    }
    void CalculateSail()
    {
        speed = 0;

        foreach (var sail in sails)
        {
            speed += sail.Speed;
        }
    }
    void CalculateCrew()
    {
        //Benötigt Gameplay Tests für die Implementierung;
        return;
    }
}