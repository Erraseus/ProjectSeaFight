using UnityEngine;

[System.Serializable]
public class UnlockRequirements
{
    #region Properties
    public CraftingMaterial Material => _material;
    public int Amount => _amount;
    #endregion

    [SerializeField] private CraftingMaterial _material;
    [SerializeField] private int _amount;
}
public enum Rarities { common, uncommon, rare, veryRare, legendary, empty }
public enum UnlockType { buy, loot, quest, achievement }
public enum CrewmateBonus { bonusSight, bonusSpeed, bonusReloadTime, bonusRepairSpeed }
public enum CannonballEffect { None, Burn, Frost, Toxic }