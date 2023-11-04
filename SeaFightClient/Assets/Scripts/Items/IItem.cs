using UnityEngine;

public interface IItem
{
    int Id { get; }
    string Name { get; }
    Sprite Icon { get; }
    string Description { get; }
}