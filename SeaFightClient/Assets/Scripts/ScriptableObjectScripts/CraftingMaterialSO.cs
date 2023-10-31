using UnityEngine;

[CreateAssetMenu(menuName = "Components/Crafting Material", fileName = "NewCraftingMaterial")]
public class CraftingMaterialSO : ScriptableObject
{
    public int id;
    [Space]
    [Header("General Information")]
    public new string name;
    public Sprite icon;
    [Space]
    [Header("Specific Information")]
    public int price;
    [TextArea(minLines: 3, maxLines: 3)]public string description;
    [Space]
    public Rarity rarity;
    public enum Rarity { common, rare, veryRare, legendary}
}