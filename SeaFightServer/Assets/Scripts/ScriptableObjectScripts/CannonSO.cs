using UnityEngine;

[CreateAssetMenu(menuName = "Components/Cannon", fileName = "NewCannon")]
public class CannonSO : ScriptableObject
{
    public int id;
    [Space]
    [Header("General Information")]
    public new string name;
    public Sprite icon;
    [Space]
    [Header("Specific Information")]
    public int damage;
    public float range;
    public float reloadTime;
    [Space]
    [Range(0f, 100f)] public float hitChance;
    [Range(0f, 100f)] public float critChance;
}