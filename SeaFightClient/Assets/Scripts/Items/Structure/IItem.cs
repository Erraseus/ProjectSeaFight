using UnityEngine;

public interface IItem
{
    int Id { get; }
    string Name { get; }
    Rarities Rarity { get; }
    Sprite Icon { get; }
    string Description { get; }
}