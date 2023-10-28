using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] [Range(0,2)] int DEBUGShiplevel;
    [SerializeField][Range(0, 2)] int DEBUGCannonlevel;
    [SerializeField][Range(0, 2)] int DEBUGSaillevel;

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
        InitialiseShip();
        CalculateCannon();
        CalculateSail();
        CalculateCrew();
    }

    void InitialiseShip()
    {
        //TODO: Daten von der Datenbank ziehen//
        ship = GameObject.Find("DataManager").GetComponent<ComponentData>().ships[DEBUGShiplevel];

        for (int i = 0; i < ship.cannonSlots; i++)
        {
            cannons.Add(GameObject.Find("DataManager").GetComponent<ComponentData>().cannons[DEBUGCannonlevel]);
        }
        for (int i = 0; i < ship.sailSlots; i++)
        {
            sails.Add(GameObject.Find("DataManager").GetComponent<ComponentData>().sails[DEBUGSaillevel]);
        }
        for (int i = 0; i < ship.crewSlots; i++)
        {
            crewMembers.Add(GameObject.Find("DataManager").GetComponent<ComponentData>().crewMembers[0]);
        }
        //TODO: End
        maxHp = ship.health;
        currentHP = ship.health;
        sight = ship.sight;

        GameObject shipModel = Instantiate(ship.Model);
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
        foreach (var sail in sails)
        {
            speed += sail.speed;
        }
    }
    void CalculateCrew()
    {
        //Ben�tigt Gameplay Tests f�r die Implementierung;
        return;
    }
}