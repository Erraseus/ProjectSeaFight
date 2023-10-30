using UnityEngine;

[CreateAssetMenu(menuName = "Components/Crew", fileName = "Crew")]
public class CrewSO : ScriptableObject
{
    public int id;
    [Space]
    [Header("General Information")]
    public new string name;
    public Sprite icon;
    [Header("Specific Information")]
    public CrewType type;
    public float value;

    public enum CrewType { bonusSight, bonusSpeed, bonusReloadTime, bonusRepairSpeed }
}