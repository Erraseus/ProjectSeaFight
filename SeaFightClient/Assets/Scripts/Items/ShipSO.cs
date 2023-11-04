using UnityEngine;

[CreateAssetMenu(menuName = "Components/Ship", fileName = "NewShip")]
public class ShipSO : ScriptableObject, IItem
{
    [Header("General Information")]
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField][TextArea(minLines: 4, maxLines: 4)] private string _description;
    [Space]
    [Header("Specific Information")]
    [SerializeField] private GameObject _model;
    [SerializeField] private float _sight;
    [SerializeField] private int _health;
    [Space]
    [Header("Ship Slots")]
    [SerializeField] private int _cannonSlots;
    [SerializeField] private int _sailSlots;
    [SerializeField] private int _crewSlots;
    [Space]
    [SerializeField] private int _inventorySlots;

    public int Id { get { return _id; } }
    public string Name { get { return _name; } }
    public Sprite Icon { get { return _icon; } }
    public string Description { get { return _name; } }
    public GameObject Model { get { return _model; } }
    public float Sight { get { return _sight; } }
    public int Health { get { return _health; } }
    public int CannonSlots { get { return _cannonSlots; } }
    public int SailSlots { get { return _sailSlots; } }
    public int CrewSlots { get { return _crewSlots; } }
    public int InventorySlots { get { return _inventorySlots; } }
}