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

    public List<Ship> ships = new List<Ship>();
    public List<Cannon> cannons = new List<Cannon>();
    public List<Sail> sails = new List<Sail>();
    public List<Crewmate> crewMembers = new List<Crewmate>();
    public List<Cannonball> cannonballs = new List<Cannonball>();
    public List<CraftingMaterial> craftingMaterials = new List<CraftingMaterial>();
}