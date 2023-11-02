using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    #region Singleton
    private static ItemDataManager _singleton;
    public static ItemDataManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(ItemDataManager)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        Singleton = this;
    }
    #endregion

    public List<ShipSO> ships = new List<ShipSO>();
    public List<CannonSO> cannons = new List<CannonSO>();
    public List<SailSO> sails = new List<SailSO>();
    public List<CrewSO> crewMembers = new List<CrewSO>();
    public List<CannonballSO> cannonballs = new List<CannonballSO>();
    public List<CraftingMaterialSO> craftingMaterials = new List<CraftingMaterialSO>();
}