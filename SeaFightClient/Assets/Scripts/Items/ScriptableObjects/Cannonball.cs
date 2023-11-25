using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Craftable/Cannonball", fileName = "new Cannonball")]
public class Cannonball : ScriptableObject, IItem, ICraftableItem, IInventoryItem
{
    #region Properties
    //Item
    public int Id => _id;
    public string Name => _name;
    public Sprite Icon => _icon;
    public Rarities Rarity => _rarity;
    public string Description => _description;
    //Craftable
    public UnlockType UnlockBy => _unlockBy;
    public string DescriptionToUnlock => _descriptionToUnlock;
    public int CraftableAtLevel => _craftableAtLevel;
    public int GoldRequirement => _goldRequirement;
    public List<UnlockRequirements> Requirements => _requirements;
    public bool IsUnlocked => _isUnlocked;
    //Inventory
    public bool IsTradeable => _isTradeable;
    public bool IsUnique => _isUnique;
    public int Price => _price;
    public int StackQuantity => _stackQuantity;
    //Cannonball
    public int Damage => _damage;
    public CannonballEffect Effect => _effect;
    public int EffectDamage => _effectDamage;
    public float EffectDuration => _effectDuration;
    #endregion

    [Header("Item Settings")]
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Rarities _rarity;
    [SerializeField][TextArea] private string _description;

    [Header("Craftable Settings")]
    [SerializeField] private UnlockType _unlockBy;
    [SerializeField][TextArea] private string _descriptionToUnlock;
    [SerializeField] private int _craftableAtLevel;
    [SerializeField] private int _goldRequirement;
    [SerializeField] private List<UnlockRequirements> _requirements;
    private bool _isUnlocked;

    [Header("Inventory Settings")]
    [SerializeField] private bool _isTradeable;
    [SerializeField] private bool _isUnique;
    [SerializeField] private int _price;
    [SerializeField] private int _stackQuantity;

    [Header("Cannonball Settings")]
    [SerializeField] private int _damage;
    [SerializeField] private CannonballEffect _effect;
    [SerializeField] private int _effectDamage;
    [SerializeField] private float _effectDuration;   
}