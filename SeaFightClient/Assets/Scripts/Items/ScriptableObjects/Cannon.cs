using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Craftable/Cannon", fileName = "new Cannon")]
public class Cannon : ScriptableObject, IItem, ICraftableItem
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
    //Cannon
    public int Damage => _damage;
    public float Range => _range;
    public float ReloadTime => _reloadTime;
    public float Hitchance => _hitchance;
    public float Critchance => _critchance;
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

    [Header("Cannon Settings")]
    [SerializeField] private int _damage;
    [SerializeField] private float _range;
    [SerializeField] private float _reloadTime;
    [SerializeField][Range(0f, 100f)] private float _hitchance;
    [SerializeField][Range(0f, 100f)] private float _critchance;
}