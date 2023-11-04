using UnityEngine;

[CreateAssetMenu(menuName = "Components/Cannonball", fileName = "NewCannonball")]
public class CannonballSO : ScriptableObject, IItem
{
    [Header("General Information")]
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField][TextArea(minLines: 4, maxLines: 4)] private string _description;
    [Space]
    [Header("Specific Information")]
    [SerializeField] private int _damage;
    [SerializeField] private CannonballType _effect;
    [SerializeField] private int _effectDamage;
    [SerializeField] private float _effectDuration;

    public int Id { get { return _id; } }
    public string Name { get { return _name; } }
    public Sprite Icon { get { return _icon; } }
    public string Description { get { return _name; } }
    public int Damage { get { return _damage; } }
    public CannonballType Effect { get { return _effect; } }
    public int EffectDamage { get { return _effectDamage; } }
    public float EffectDuration { get { return _effectDuration; } }
}

public enum CannonballType { None, Burn, Frost, Toxic }