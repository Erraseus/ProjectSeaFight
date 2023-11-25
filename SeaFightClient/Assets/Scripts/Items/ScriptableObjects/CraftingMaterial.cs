using UnityEngine;

[CreateAssetMenu(menuName = "Item/Inventory/Crafting Material", fileName = "new CraftingMaterial")]
public class CraftingMaterial : ScriptableObject, IItem, IInventoryItem
{
    #region Properties
    //Item
    public int Id => _id;
    public string Name => _name;
    public Sprite Icon => _icon;
    public Rarities Rarity => _rarity;
    public string Description => _description;
    //Inventory
    public bool IsTradeable => _isTradeable;
    public bool IsUnique => _isUnique;
    public int Price => _price;
    public int StackQuantity => _stackQuantity;
    #endregion

    [Header("Item Settings")]
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Rarities _rarity;
    [SerializeField] [TextArea] private string _description;

    [Header("Inventory Settings")]
    [SerializeField] private bool _isTradeable;
    [SerializeField] private bool _isUnique;
    [SerializeField] private int _price;
    [SerializeField] private int _stackQuantity;
}