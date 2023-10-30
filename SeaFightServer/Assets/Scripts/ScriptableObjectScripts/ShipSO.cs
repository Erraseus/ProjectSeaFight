using UnityEngine;

[CreateAssetMenu(menuName = "Components/Ship", fileName = "NewShip")]
public class ShipSO : ScriptableObject
{
    public int id;
    [Space]
    [Header("General Information")]
    public new string name;
    public Sprite icon;
    [Space]
    [Header("Specific Information")]
    public GameObject Model;
    public float sight;
    public int health;
    [Space]
    [Header("Ship Slots")]
    public int cannonSlots;
    public int sailSlots;
    public int crewSlots;
    [Space]
    public int inventorySlots;
}