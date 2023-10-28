using UnityEngine;

[CreateAssetMenu(menuName = "Components/Cannonball", fileName = "NewCannonball")]
public class CannonballSO : ScriptableObject
{
    public int id;
    [Space]
    [Header("General Information")]
    public new string name;
    public Sprite icon;
    [Header("Specific Information")]
    public int damage;
    public CannonballType effect;
    public int effectDamage;
    public float effectDuration;

    public enum CannonballType { None, Burn, Frost, Toxic }
}