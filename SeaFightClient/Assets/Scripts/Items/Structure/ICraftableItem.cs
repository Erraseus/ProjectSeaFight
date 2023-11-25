using UnityEngine;
using System.Collections.Generic;

public interface ICraftableItem : IItem
{
    public UnlockType UnlockBy { get; }
    public string DescriptionToUnlock { get; }
    public int CraftableAtLevel { get; }
    public int GoldRequirement { get; }
    public List<UnlockRequirements> Requirements { get; }
    public bool IsUnlocked { get; }
}