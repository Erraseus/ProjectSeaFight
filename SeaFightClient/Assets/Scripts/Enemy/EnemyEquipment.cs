using System.Collections.Generic;
using UnityEngine;

public class EnemyEquipment : MonoBehaviour
{
    [Header("DataManager")]
    [SerializeField] LocalDatabase shipComponent;

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
        shipComponent = GameObject.Find("DataManager").GetComponent<LocalDatabase>();

        InitialiseShip();
        CalculateCannon();
        CalculateSail();
        CalculateCrew();
    }

    void InitialiseShip()
    {
        ship = shipComponent.ships[0];

        for (int i = 0; i < ship.cannonSlots; i++)
        {
            cannons.Add(shipComponent.cannons[0]);
        }
        for (int i = 0; i < ship.sailSlots; i++)
        {
            sails.Add(shipComponent.sails[0]);
        }
        for (int i = 0; i < ship.crewSlots; i++)
        {
            crewMembers.Add(shipComponent.crewMembers[0]);
        }

        maxHp = ship.health;
        currentHP = ship.health;
        sight = ship.sight;

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
            damage += cannon.damage;
            attackRange += cannon.range;
            reloadTime += cannon.reloadTime;
            hitChance += cannon.hitChance;
            critChance += cannon.critChance;
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
            speed += sail.speed;
        }
    }
    void CalculateCrew()
    {
        //Benötigt Gameplay Tests für die Implementierung;
        return;
    }
}
