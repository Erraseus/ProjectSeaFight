using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    private ItemDataManager _equipmentId;
    
    [SerializeField] private int _playerLevel;

    [SerializeField] private Ship _ship;
    [SerializeField] private List<Cannon> _cannons = new List<Cannon>();
    [SerializeField] private List<Sail> _sails = new List<Sail>();
    
    [Header("Cannon Data")]
    [SerializeField] private int damage = 0;
    [SerializeField] private float attackRange = 0f;
    [SerializeField] private float reloadTime = 0f;
    [SerializeField] private float hitChance = 0f;
    [SerializeField] private float critChance = 0f;

    [Header("Sails Data")]
    [SerializeField] private float speed = 0f;

    void Start()
    {
        _equipmentId = ItemDataManager.Singleton.GetComponent<ItemDataManager>();

        InitialiseShip();
        CalculateCannons();
        CalculateSail();
    }

    void InitialiseShip()
    {
        _ship = _equipmentId.ships[0];

        for (int i = 0; i < _ship.CannonSlots; i++)
        {
            _cannons.Add(_equipmentId.cannons[0]);
        }
        for (int i = 0; i < _ship.SailSlots; i++)
        {
            _sails.Add(_equipmentId.sails[0]);
        }
        
        GameObject shipModel = Instantiate(_ship.Model, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
        shipModel.tag = "Player";
        shipModel.transform.SetParent(transform);
    }

    void CalculateCannons()
    {
        damage = 0;
        attackRange = 0;
        reloadTime = 0;
        hitChance = 0;
        critChance = 0;

        foreach (var cannon in _cannons)
        {
            damage += cannon.Damage;
            attackRange += cannon.Range;
            reloadTime += cannon.ReloadTime;
            hitChance += cannon.Hitchance;
            critChance += cannon.Critchance;
        }
        if (_cannons.Count > 0)
        {
            attackRange /= _cannons.Count;
            reloadTime /= _cannons.Count;
            hitChance /= _cannons.Count;
            critChance /= _cannons.Count;
        }
    }

    void CalculateSail()
    {
        speed = 0;

        foreach (var sail in _sails)
        {
            speed += sail.Speed;
        }
    }

    public void SetPlayerLevel(int id)
    {
        _playerLevel = id;
    }
}