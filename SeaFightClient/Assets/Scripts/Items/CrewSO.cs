using UnityEngine;

[CreateAssetMenu(menuName = "Components/Crew", fileName = "Crew")]
public class CrewSO : ScriptableObject, IItem
{
    [Header("General Information")]
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField][TextArea(minLines: 4, maxLines: 4)] private string _description;
    [Space]
    [Header("Specific Information")]
    [SerializeField] private CrewType _type;
    [SerializeField] private float _value;

    public int Id { get { return _id; } }
    public string Name { get { return _name; } }
    public Sprite Icon { get { return _icon; } }
    public string Description { get { return _name; } }
    public CrewType Type { get { return _type; } }
    public float Value { get { return _value; } }
}

public enum CrewType { bonusSight, bonusSpeed, bonusReloadTime, bonusRepairSpeed }