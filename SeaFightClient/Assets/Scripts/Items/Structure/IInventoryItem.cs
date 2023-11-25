using UnityEngine;

public interface IInventoryItem : IItem
{
    public bool IsTradeable { get; }
    public bool IsUnique { get; }
    public int Price { get; }
    public int StackQuantity { get; }
}