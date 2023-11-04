using UnityEngine;

[CreateAssetMenu(menuName = "Components/Crafting Material", fileName = "NewCraftingMaterial")]
public class CraftingMaterialSO : ScriptableObject, IItem
{
    [Header("General Information")]
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField][TextArea(minLines: 4, maxLines: 4)] private string _description;
    [Space]
    [Header("Specific Information")]
    [SerializeField] private int _price;
    [SerializeField] private int _stack;
    [Space]
    [SerializeField] private RARITY _rarity;

    public int Id { get { return _id; } }
    public string Name { get { return _name; } }
    public Sprite Icon { get { return _icon; } }
    public string Description { get { return _description; } }
    public int Price { get { return _price; } }
    public int Stack { get { return _stack; } }
    public RARITY Rarity { get { return _rarity; } }
}

public enum RARITY { common, rare, veryRare, legendary }